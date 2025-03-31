using InfoTech_RegistrySearch_Domain.HtmlParser;
using InfoTech_RegistrySearch_Domain.SearchInput;
using Infotech_RegistrySearch_MatthewBrady.Server.Requests;
using Infotech_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotech_RegistrySearch_MatthewBrady.Server.Services
{
    public class SearchApplicationService : ISearchApplicationService
    {
        private readonly ISearchEngineParser _searchEngineParser;

        public SearchApplicationService(ISearchEngineParser searchEngineParser)
        {
            _searchEngineParser = searchEngineParser;
        }

        public SearchApplicationService()
        {
            _searchEngineParser = new SearchEngineParser();
        }

        public SearchResultViewModel PerformSearch(SearchQueryRequest searchQueryRequest)
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
                Url = searchResults.Url.Url.AbsoluteUri
            };


            return outputList;
        }
    }
}
