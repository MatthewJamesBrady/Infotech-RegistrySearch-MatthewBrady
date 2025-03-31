using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_RegistrySearch_Domain.Trends
{
    public interface ISearchTrendService
    {
        Task<IEnumerable<SearchResults>> GetAllHistory();
        Task<List<SearchWeeklyHistory>> GetAllWeeklyHistory();
    }

    public class SearchTrendService : ISearchTrendService
    {
        public ISearchResultRepository SearchResultRepository { get; set; }

        public SearchTrendService(ISearchResultRepository searchResultRepository)
        {
            SearchResultRepository = searchResultRepository;
        }


        public async Task<IEnumerable<SearchResults>> GetAllHistory()
        {
            return await this.SearchResultRepository.GetAllAsync();
        }

        public async Task<List<SearchWeeklyHistory>> GetAllWeeklyHistory()
        {
            var allHistory =  await this.SearchResultRepository.GetAllAsync();

            return allHistory
                .GroupBy(r => new
                {
                    
                    Phrase = r.Phrase.Phrase,
                    Engine = r.SearchEngineUrl,
                    WeekStart = r.RetirevalDate,
                    Url = r.Url
                })
                .Select(g => new SearchWeeklyHistory
                {
                    SearchPhrase = g.Key.Phrase,
                    SearchEngine = g.Key.Engine,
                    Url = g.Key.Url.Url.AbsoluteUri,
                    WeekStart = g.Key.WeekStart,
                    Count = g.Sum(x => x.Count)
                })
                .OrderBy(t => t.WeekStart)
                .ThenBy(t => t.SearchEngine)
                .ThenBy(t => t.SearchPhrase)
                .ToList();
        }
    }

    public class SearchWeeklyHistory
    {
        public string SearchEngine { get; set; }

        public string SearchPhrase { get; set; }

        public string Url { get; set; }

        public int Count { get; set; }

        public DateOnly WeekStart { get; set; }

        
    }
    
}
