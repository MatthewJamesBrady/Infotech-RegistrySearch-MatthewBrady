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
            var orderdVms = getHistory
                .OrderBy(x => x.RetirevalDate)
                .ThenBy(x => x.SearchEngineUrl )
                .ThenBy(x => x.Phrase.Phrase);

            foreach (var searchResultl in orderdVms)
            {
                var vm = new SearchResultViewModel
                {
                    Url = searchResultl.Url.Url.AbsoluteUri,
                    FormattedOutput = searchResultl.ProduceFormattedOutput(),
                    SearchEngine = searchResultl.SearchEngineUrl,
                    SearchPhrase = searchResultl.Phrase.Phrase,
                    Count = searchResultl.Count,
                    Date = searchResultl.RetirevalDate
                };

                listOfViewModels.Add(vm);
            }

            return listOfViewModels;
        }

        public async Task<List<SearchWeeklyHistoryViewModel>> SearchAllWeeklyHistory()
        {
            var weeklyHistory = await _searchTrendService.GetAllWeeklyHistory();

            var orderdedHistory = weeklyHistory
                .OrderBy(x => x.WeekStart).ThenBy(x => x.SearchEngine)
                .ThenBy(x => x.SearchPhrase);

            var weeklyVms = new List<SearchWeeklyHistoryViewModel>();

            foreach (var searchWeeklyHistory in orderdedHistory)
            {
                var weeklyVm = new SearchWeeklyHistoryViewModel
                {
                    SearchEngine = searchWeeklyHistory.SearchEngine,
                    SearchPhrase = searchWeeklyHistory.SearchPhrase,
                    Url = searchWeeklyHistory.Url,
                    WeekStart = searchWeeklyHistory.WeekStart,
                    Count = searchWeeklyHistory.Count
                };

                weeklyVms.Add(weeklyVm);
            }

            return weeklyVms;

        }
    }
}
