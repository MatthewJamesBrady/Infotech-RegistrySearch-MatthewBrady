using InfoTech_RegistrySearch_Domain.Trends;
using Infotech_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotech_RegistrySearch_MatthewBrady.Server.Services
{
    public class SearchHistoryApplicationService : ISearchHistoryApplicationService
    {
        private readonly ISearchTrendService _searchTrendService;

        public SearchHistoryApplicationService(ISearchTrendService searchTrendService)
        {
            _searchTrendService = searchTrendService;
        }

       

        public async Task<List<SearchResultViewModel>> SearchAllDailyHistory()
        {
            var getHistory = await _searchTrendService.GetAllHistory();
            var listOfViewModels = new List<SearchResultViewModel>();

            foreach (var searchResultl in getHistory)
            {
                var vm = new SearchResultViewModel
                {
                    Url = searchResultl.Url.Url.AbsoluteUri,
                    FormattedOutput = searchResultl.ProduceFormattedOutput(),
                    SearchEngine = searchResultl.SearchEngineUrl,
                    SearchPhrase = searchResultl.Phrase.Phrase,
                    Count = searchResultl.Count
                };

                listOfViewModels.Add(vm);
            }

            return listOfViewModels;
        }

        public async Task<List<SearchWeeklyHistoryViewModel>> SearchAllWeeklyHistory()
        {
            var weeklyHistory = await _searchTrendService.GetAllWeeklyHistory();

            var weeklyVms = new List<SearchWeeklyHistoryViewModel>();

            foreach (var searchWeeklyHistory in weeklyHistory)
            {
                var weeklyVm = new SearchWeeklyHistoryViewModel
                {
                    SearchEngine = searchWeeklyHistory.SearchEngine,
                    SearchPhrase = searchWeeklyHistory.SearchPhrase,
                    Url = searchWeeklyHistory.Url,
                    WeekStart = searchWeeklyHistory.WeekStart
                };
            }

            return weeklyVms;

        }
    }
}
