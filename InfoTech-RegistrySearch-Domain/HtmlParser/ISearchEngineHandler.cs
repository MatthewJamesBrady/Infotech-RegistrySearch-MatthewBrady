using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser;

public interface ISearchEngineHandler
{
    SearchEngine Engine { get; }
    SearchResults PerformSearch(SearchQuery query);
}