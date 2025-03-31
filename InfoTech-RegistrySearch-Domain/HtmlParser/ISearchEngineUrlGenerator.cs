using InfoTech_RegistrySearch_Domain.SearchInput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser;

public interface ISearchEngineUrlGenerator
{
    string GenerateUrl(SearchQuery query);
}