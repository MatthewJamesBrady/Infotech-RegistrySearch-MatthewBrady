using InfoTech_Data.SearchResultsData;
using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;
using Microsoft.OpenApi.Services;

namespace Infotech_RegistrySearch_MatthewBrady.Server.TestData
{
    public class SeedData
    {
        private ISearchResultRepository SearchResultRepository { get; }

        public SeedData(ISearchResultRepository searchResultRepository)
        {
            SearchResultRepository = searchResultRepository;
        }

        public async Task PopulateSearchHistory()
        {
            var listOfSearchResults = new List<SearchResults>()
            {
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 1), 3),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 2), 0),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 3), 5),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 4), 4),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 5), 6),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 6), 7),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 7), 8),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 8), 7),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 9), 8),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 10), 9),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 11), 10),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 12), 11),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 13), 12),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 14), 15),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 15), 16),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 16), 15),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 17), 17),
                CreateGoogleInfotechSearchResults(new DateOnly(2025, 3, 18), 20),

            };

            foreach (var searchResult in listOfSearchResults)
            {
                await SearchResultRepository.Upsert(searchResult);
            }



            return;
        }

        private SearchResults CreateGoogleInfotechSearchResults(DateOnly date, int count)
        {
            return new SearchResults()
            {
                Count = count,
                RetirevalDate = date,
                Phrase = new SearchPhrase("land registry search"),
                SearchEngineUrl = "Google",
                Url = new SearchUrl("https://www.infotech.com")
            };
        }
    }
}
