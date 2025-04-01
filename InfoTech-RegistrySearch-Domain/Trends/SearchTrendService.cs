using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrack_RegistrySearch_Domain.SearchOutput;
using Microsoft.VisualBasic;

namespace InfoTrack_RegistrySearch_Domain.Trends
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
                    WeekStart = GetStartOfWeek(r.RetirevalDate) ,
                    Url = r.Url.Url.AbsoluteUri
                })
                .Select(g => new SearchWeeklyHistory
                {
                    SearchPhrase = g.Key.Phrase,
                    SearchEngine = g.Key.Engine,
                    Url = g.Key.Url ,
                    WeekStart = g.Key.WeekStart,
                    Count = g.Sum(x => x.Count)
                })
                .OrderBy(t => t.WeekStart)
                .ThenBy(t => t.SearchEngine)
                .ThenBy(t => t.SearchPhrase)
                .ToList();
        }

        public static DateOnly GetStartOfWeek(DateOnly date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff);
        }
    }
}
