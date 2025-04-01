using InfoTrack_RegistrySearch_Domain.SearchInput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser;

public interface ISearchEngineUrlGenerator
{
    string GenerateUrl(SearchQuery query);
}