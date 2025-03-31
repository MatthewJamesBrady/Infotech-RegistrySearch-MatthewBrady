
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech_RegistrySearch_Domain.HtmlParser;
using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;

namespace InfoTech_Data.SearchResultsData
{
    internal class SearchResultsMapper
    {

        public SearchResultsEntity ToDto(SearchResults domain)
        {
            return new SearchResultsEntity
            {
                Phrase = domain.Phrase.Phrase,
                SearchEngineUrl = domain.SearchEngineUrl,
                Url = domain.Url.Url.AbsoluteUri,
                Count = domain.Count
            };
        }

        public SearchResults ToDomain(SearchResultsEntity dto)
        {
            var searchResults = new SearchResults();
            searchResults.SearchEngineUrl = dto.SearchEngineUrl;
            searchResults.Count = dto.Count;
            searchResults.Url = new SearchUrl(dto.Url);
            searchResults.Phrase = new SearchPhrase();
            searchResults.Phrase.Phrase = dto.Phrase;

            return searchResults;
        }
    }
}
