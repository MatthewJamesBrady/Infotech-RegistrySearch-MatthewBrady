using InfoTrack_RegistrySearch_Domain.SearchInput;
using Infotrack_RegistrySearch_MatthewBrady.Server.Requests;
using Infotrack_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotrack_RegistrySearch_MatthewBrady.Server.Services;

public interface ISearchApplicationService
{
    Task<SearchResultViewModel> PerformSearch(SearchQueryRequest searchQueryRequest);
}