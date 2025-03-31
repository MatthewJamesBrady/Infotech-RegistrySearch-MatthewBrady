using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech_RegistrySearch_Domain.SearchInput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser.Bing
{
    public class BingSearchEngineUrlGenerator : ISearchEngineUrlGenerator
    {
        public const string BaseEngineURl = "https://www.bing.co.uk/search?";

        // number of results to return
        // default 100
        public int NumberOfResults = 20;

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
}
