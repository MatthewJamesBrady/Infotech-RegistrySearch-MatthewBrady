using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser.Google;

public class GoogleSearchHandler : ISearchEngineHandler
{
    public SearchEngine Engine => SearchEngine.Google;

    public SearchResults PerformSearch(SearchQuery query)
    {
        IPageReader reader = new GooglePageReader();
        IPageDownloader loader = new PageDownloader();
        var processor = new PageProcessor(reader, loader);
        return processor.Process(query);
    }
}