using InfoTrack_RegistrySearch_Domain.HtmlParser.Google;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser.Bing;

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