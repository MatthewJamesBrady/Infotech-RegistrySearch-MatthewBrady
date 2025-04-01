using InfoTrack_RegistrySearch_Domain.HtmlParser;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;
using Infotrack_RegistrySearch_MatthewBrady.Server.Requests;
using Infotrack_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotrack_RegistrySearch_MatthewBrady.Server.Services
{
    public class SearchApplicationService : ISearchApplicationService
    {
        private readonly ISearchEngineParser _searchEngineParser;

        private readonly ISearchResultRepository _repository;

        public SearchApplicationService(ISearchEngineParser searchEngineParser, ISearchResultRepository repository)
        {
            _searchEngineParser = searchEngineParser;
            _repository = repository;
        }

        public SearchApplicationService(ISearchResultRepository repository)
        {
            _repository = repository;
            _searchEngineParser = new SearchEngineParser();
        }

        public async Task<SearchResultViewModel> PerformSearch(SearchQueryRequest searchQueryRequest)
        {
            var engine = Enum.Parse<SearchEngine>(searchQueryRequest.Engine, ignoreCase: true);

            var searchQuery = new SearchQuery(
                new SearchUrl(searchQueryRequest.Url), 
                new SearchPhrase(searchQueryRequest.Phrase),
                engine
                );

            var searchResults = _searchEngineParser.PerformSearch(searchQuery);

            var list = searchResults.SearchResultLines;
            var outputList = new SearchResultViewModel
            {
                SearchEngine = searchQuery.SearchEngine.ToString(),
                FormattedOutput = searchResults.ProduceFormattedOutput(),
                SearchPhrase = searchResults.Phrase.Phrase,
                Url = searchResults.Url.Url.AbsoluteUri,
                Count = searchResults.Count ,
                Date = DateOnly.FromDateTime(DateTime.Now) 
            };


            await this._repository.Upsert(searchResults);

            return outputList;
        }
    }
}
