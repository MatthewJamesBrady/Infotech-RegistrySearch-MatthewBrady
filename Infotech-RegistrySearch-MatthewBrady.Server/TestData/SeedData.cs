using InfoTrack_Data.SearchResultsData;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using InfoTrack_RegistrySearch_Domain.SearchOutput;
using Microsoft.OpenApi.Services;

namespace Infotrack_RegistrySearch_MatthewBrady.Server.TestData
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
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 1), 3),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 2), 0),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 3), 5),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 4), 4),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 5), 6),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 6), 7),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 7), 8),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 8), 7),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 9), 8),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 10), 9),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 11), 10),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 12), 11),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 13), 12),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 14), 15),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 15), 16),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 16), 15),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 17), 17),
                CreateGoogleInfotrackSearchResults(new DateOnly(2025, 3, 18), 20),

            };

            foreach (var searchResult in listOfSearchResults)
            {
                await SearchResultRepository.Upsert(searchResult);
            }



            return;
        }

        private SearchResults CreateGoogleInfotrackSearchResults(DateOnly date, int count)
        {
            return new SearchResults()
            {
                Count = count,
                RetirevalDate = date,
                Phrase = new SearchPhrase("land registry search"),
                SearchEngineUrl = "Google",
                Url = new SearchUrl("https://www.infotrack.com")
            };
        }
    }
}
