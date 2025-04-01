using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrack_RegistrySearch_Domain.HtmlParser.Bing;
using InfoTrack_RegistrySearch_Domain.HtmlParser.Google;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_RegistrySearch_Domain.HtmlParser
{
    public interface IPageProcessor
    {
        SearchResults Process(SearchQuery query);
    }

    public class PageProcessor : IPageProcessor
    {
        private readonly IPageReader _reader;
        private readonly IPageDownloader _loader;

        public PageProcessor(IPageReader reader, IPageDownloader loader)
        {
            this._reader = reader;
            this._loader = loader;
        }

        public SearchResults Process(SearchQuery query)
        {
            ISearchEngineUrlGenerator searchUrlGenerator;

            if (query.SearchEngine == SearchEngine.Google)
            {
                searchUrlGenerator = new GoogleSearchEngineUrlGenerator();
            }
            else
            {
                searchUrlGenerator = new BingSearchEngineUrlGenerator();
            }
              
            var searchUrl = searchUrlGenerator.GenerateUrl(query);

            var loadResult = this._loader.DownloadPage(searchUrl, query.SearchEngine.ToString(), true);

            if (loadResult == null)
            {
                throw new Exception("Failed to load page");
            }
            this._reader.Text = loadResult;
            var searchResults = this._reader.Read(loadResult, query);

            return searchResults;
        }
    }
}
