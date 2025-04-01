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
    //public class SearchEngineParser : ISearchEngineParser
    //{
    //    public SearchResults PerformSearch(SearchQuery searchQuery)
    //    {
    //        var engine = searchQuery.SearchEngine;

    //        switch (engine)
    //        {
    //            case SearchEngine.Google:
    //            {
    //                IPageReader reader = new GooglePageReader();
    //                IPageDownloader loader = new PageDownloader();
    //                var pageProcessor = new PageProcessor(reader, loader);

    //                var result = pageProcessor.Process(searchQuery);
    //                return result;
    //                break;
    //            }
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }
    //    }

    //}

    public class SearchEngineParser : ISearchEngineParser
    {
        private readonly Dictionary<SearchEngine, ISearchEngineHandler> _handlers;

        // Manual creation seeing as i've not yet implemented DI
        public SearchEngineParser()
        {
            var googleHandler = new GoogleSearchHandler();
            var bingHandler = new BingSearchHandler();

            var handlers = new List<ISearchEngineHandler>
            {
                googleHandler,
                bingHandler
            };

            var handlerDict = handlers.ToDictionary(h => h.Engine);
            this._handlers = handlerDict;
        }

        public SearchEngineParser(IEnumerable<ISearchEngineHandler> handlers)
        {
            _handlers = handlers.ToDictionary(h => h.Engine);
        }

        public SearchResults PerformSearch(SearchQuery query)
        {
            if (_handlers.TryGetValue(query.SearchEngine, out var handler))
            {
                return handler.PerformSearch(query);
            }

            throw new NotSupportedException($"No handler for engine: {query.SearchEngine}");
        }
    }

    public enum SearchEngine
    {
        Google,
        Bing,
        Yahoo
    }
}
