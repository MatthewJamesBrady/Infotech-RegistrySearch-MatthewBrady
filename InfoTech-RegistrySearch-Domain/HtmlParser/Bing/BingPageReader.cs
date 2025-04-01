using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_RegistrySearch_Domain.HtmlParser.Bing
{
    public class BingPageReader : IPageReader
    {
        public string Text { get; set; }
        public string FindFirstSearchResult(SearchQuery input)
        {
            var searchText = CreateSearchText();

            var firstResult = Regex.Match(Text, searchText);
            return firstResult.Value;
        }

        public SearchResults Read(string loadResult, SearchQuery query)
        {
            Text = loadResult;

            var searchResults = new SearchResults
            {
                Url = query.Url,
                Phrase = query.Phrase,
                SearchEngineUrl = query.SearchEngine.ToString(),
                RetirevalDate = DateOnly.FromDateTime(DateTime.Now)
            };

            string targetHost = query.Url.Url.Host.Replace("www.", "");

            // Match all Bing organic result blocks
            var matches = Regex.Matches(
                loadResult,
                @"<li class=""b_algo""[^>]*?>.*?</li>",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            int resultIndex = 1;

            foreach (Match match in matches)
            {
                string block = match.Value;

                // Extract the anchor tag within
                var anchorMatch = Regex.Match(block, @"<a[^>]+href=\""(?<url>https?://[^\""]+)\""", RegexOptions.IgnoreCase);
                if (anchorMatch.Success)
                {
                    string url = anchorMatch.Groups["url"].Value;

                    try
                    {
                        var uri = new Uri(url);
                        string linkHost = uri.Host.Replace("www.", "");

                        if (linkHost == targetHost)
                        {
                            Console.WriteLine($"Match at position {resultIndex + 1}: {url}");
                            searchResults.AddLineNumber(resultIndex, url);
                        }
                        else
                        {
                            Console.WriteLine($"Skipped (host doesn’t match): {url}");
                        }

                        resultIndex++; // Increment only for real organic results
                    }
                    catch (UriFormatException)
                    {
                        Console.WriteLine($"Invalid URL skipped: {url}");
                    }
                }
            }

            return searchResults;
        }

        private string CreateSearchText()
        {
            var searchText = @"(<a.*?>.*?</a>)";
            return searchText;
        }
    }
}
