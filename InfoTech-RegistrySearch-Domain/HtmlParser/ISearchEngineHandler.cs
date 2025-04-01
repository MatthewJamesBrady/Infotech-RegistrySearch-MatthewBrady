using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser;

public interface ISearchEngineHandler
{
    SearchEngine Engine { get; }
    SearchResults PerformSearch(SearchQuery query);
}