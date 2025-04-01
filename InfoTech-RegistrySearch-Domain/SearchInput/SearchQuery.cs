using InfoTrack_RegistrySearch_Domain.HtmlParser;

namespace InfoTrack_RegistrySearch_Domain.SearchInput;

public class SearchQuery(SearchUrl url, SearchPhrase phrase, SearchEngine searchEngine)
{
    public SearchUrl Url { get; set; } = url ?? throw new ArgumentNullException(nameof(url));
    public SearchPhrase Phrase { get; set; } = phrase ?? throw new ArgumentNullException(nameof(phrase));

    public SearchEngine SearchEngine { get; set; } = searchEngine;

    public static SearchQuery Create(string url, string phrase, SearchEngine searchEngine)
    {
        return new SearchQuery(new SearchUrl(url), new SearchPhrase(phrase), searchEngine);
    }
}