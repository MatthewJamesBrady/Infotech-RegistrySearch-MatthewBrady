using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTech_RegistrySearch_Domain.HtmlParser
{
    public class HttpClientSetupFactory
    {

        private  HttpClient _client;
        private Random _random;

        public async Task InitializeSession()
        {
            try
            {
                Console.WriteLine("Initializing session with google.com...");
                var response = await _client.GetAsync("https://www.google.com/");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Initial session established. Response length: {content.Length}");

                    // Check if consent page
                    if (content.Contains("consent.google.com") || content.Contains("consent required"))
                    {
                        Console.WriteLine("Consent page detected. Attempting to handle consent...");
                        await Task.Delay(_random.Next(1000, 5000));
                        await HandleConsent(content);
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to initialize session: {response.StatusCode}");
                }

                // Add a delay to mimic human behavior
                await Task.Delay(_random.Next(1000, 5000));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing session: {ex.Message}");
            }
        }

        // Handle consent pages
        public async Task HandleConsent(string content)
        {
            // This is a simplified version - the actual implementation depends on Google's current consent form
            // Looking for consent form submission URL
            string consentFormPattern = @"action=""([^""]+)""";
            var match = Regex.Match(content, consentFormPattern);

            if (match.Success)
            {
                string consentUrl = match.Groups[1].Value;
                if (!consentUrl.StartsWith("http"))
                {
                    consentUrl = "https://consent.google.com" + consentUrl;
                }

                // Create consent form data - this varies by region and may need adjustments
                var formData = new Dictionary<string, string>
            {
                { "consent", "true" },
                { "continue", "https://www.google.com/" },
                { "gl", "US" },
                { "hl", "en" },
                { "v", "0" }
            };

                var content2 = new FormUrlEncodedContent(formData);
                var response = await _client.PostAsync(consentUrl, content2);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Consent submitted successfully");
                }
                else
                {
                    Console.WriteLine($"Failed to submit consent: {response.StatusCode}");
                }
            }
        }


        public HttpClient CreateClient()
        {
            string[] userAgents =
            [
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:95.0) Gecko/20100101 Firefox/95.0",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.1 Safari/605.1.15",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36 Edg/96.0.1054.29",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36"
            ];

            var handler = new HttpClientHandler
            {
                //AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };


            var client = new HttpClient(handler);

            _random =  new Random();
            var i = _random.Next(0, 4);  
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");

            client.DefaultRequestHeaders.Add("User-Agent", userAgents[i]);

            client.Timeout = TimeSpan.FromSeconds(30);
            _client = client;
           // InitializeSession();
            return client;
        }
    }
}
