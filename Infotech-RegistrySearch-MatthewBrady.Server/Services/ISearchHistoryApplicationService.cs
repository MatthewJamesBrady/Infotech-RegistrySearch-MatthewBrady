using Infotech_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotech_RegistrySearch_MatthewBrady.Server.Services;

public interface ISearchHistoryApplicationService
{
    Task<List<SearchResultViewModel>> SearchAllDailyHistory();
    Task<List<SearchWeeklyHistoryViewModel>> SearchAllWeeklyHistory();
}