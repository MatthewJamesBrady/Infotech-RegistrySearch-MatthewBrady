using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser
{
    public class PageDownloader : IPageDownloader
    {
        private const string? RequestHeaderValue = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
        private const string UserAgent = "User-Agent";

        public string? DownloadPage(string url, string searchengine,bool usePlaywright = false)
        {
            if (usePlaywright)
            {
                return CreatePlayWrightClient(url, searchengine);
            }

           
            using var client = CreateClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var downloadPage = response.Content.ReadAsStringAsync().Result;
                var cleanedUp = HttpUtility.HtmlDecode(downloadPage);
                
                return cleanedUp;
            }
            else
            {
                return null;
            }
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClientSetupFactory().CreateClient();
            return client;
        }

        public string CreatePlayWrightClient(string url, string searchengine)
        {
            var result = ClientCreator.ScrapeWebsite(url, searchengine);
            return result;
        }
    }
}
