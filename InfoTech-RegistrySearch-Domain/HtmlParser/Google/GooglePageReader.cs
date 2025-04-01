using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser.Google
{
    public class GooglePageReader : IPageReader
    {
        public string Text { get; set; }

        public GooglePageReader()
        {

        }

        public string FindFirstSearchResult(SearchQuery input)
        {
            var searchText = CreateSearchText();

            var firstResult = Regex.Match(Text, searchText);
            return firstResult.Value;
        }

        public SearchResults Read(string loadResult, SearchQuery query)
        {
            Text = loadResult;
            //return this.FindFirstSearchResult(query);

            var searchResults = new SearchResults
            {
                Url = query.Url,
                Phrase = query.Phrase,
                SearchEngineUrl = query.SearchEngine.ToString(),
                RetirevalDate = DateOnly.FromDateTime(DateTime.Now)
            }; 

            // Find all search result containers
            var resultBlocks = Regex.Matches(
                loadResult,
                @"<div class=""MjjYud"".*?</div>\s*</div>\s*</div>",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            string targetHost = query.Url.Url.Host.Replace("www.", "");

            int realIndex = 1; // Only counts real organic results

            foreach (Match blockMatch in resultBlocks)
            {
                string block = blockMatch.Value;

                // Only include blocks that contain real organic result link container
                if (!Regex.IsMatch(block, @"<div class=""yuRUbf""", RegexOptions.IgnoreCase))
                {
                    continue; // Skip Top Stories, Video, etc.
                }

                // Find the <a href="..."> inside
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
                            Console.WriteLine($"✅ MATCH at position {realIndex + 1}: {url}");
                            searchResults.AddLineNumber(realIndex, url); // ✅ Real index
                        }
                        else
                        {
                            Console.WriteLine($"➖ Skipped (host doesn’t match): {url}");
                        }

                        realIndex++; // ✅ Increment only for valid result blocks
                    }
                    catch (UriFormatException)
                    {
                        Console.WriteLine($"⚠️ Invalid URL skipped: {url}");
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
