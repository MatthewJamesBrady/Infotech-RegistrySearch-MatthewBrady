
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrack_RegistrySearch_Domain.HtmlParser;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;

namespace InfoTrack_Data.SearchResultsData
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
                Count = domain.Count,
                RetirevalDate = domain.RetirevalDate
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
            searchResults.RetirevalDate = dto.RetirevalDate;

            return searchResults;
        }
    }
}
