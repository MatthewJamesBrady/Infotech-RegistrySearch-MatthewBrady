using InfoTech_RegistrySearch_Domain.SearchInput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser.Google;

public class GoogleSearchEngineUrlGenerator : ISearchEngineUrlGenerator
{
    // example string : https://www.google.co.uk/search?num=100&q=land+registry+search

    public const string BaseEngineURl = "https://www.google.co.uk/search?";

    // number of results to return
    // default 100
    public int NumberOfResults = 100;

        

    public string GenerateUrl(SearchQuery query)
    {
        var queryTerm = query.Phrase.Phrase;
        if (string.IsNullOrWhiteSpace(queryTerm))
        {
            throw new ArgumentNullException(nameof(queryTerm));
        }

        var generatedString = BaseEngineURl + "num=" + NumberOfResults + "&q=" + queryTerm;
        return generatedString;
    }
}