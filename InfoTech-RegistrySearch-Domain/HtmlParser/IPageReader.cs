using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser;

public interface IPageReader
{
    string Text { get; set; }
    string FindFirstSearchResult(SearchQuery input);
    SearchResults Read(string loadResult, SearchQuery query);
}