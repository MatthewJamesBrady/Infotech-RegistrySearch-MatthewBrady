using InfoTech_RegistrySearch_Domain.HtmlParser.Google;
using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser.Bing;

public class BingSearchHandler : ISearchEngineHandler
{
    public SearchEngine Engine => SearchEngine.Bing;

    public SearchResults PerformSearch(SearchQuery query)
    {
        IPageReader reader = new BingPageReader();
        IPageDownloader loader = new PageDownloader();
        var processor = new PageProcessor(reader, loader);
        return processor.Process(query);
    }
}