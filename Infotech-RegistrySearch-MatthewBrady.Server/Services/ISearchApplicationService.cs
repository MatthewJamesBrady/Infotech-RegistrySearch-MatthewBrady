using InfoTech_RegistrySearch_Domain.SearchInput;
using Infotech_RegistrySearch_MatthewBrady.Server.Requests;
using Infotech_RegistrySearch_MatthewBrady.Server.ViewModels;

namespace Infotech_RegistrySearch_MatthewBrady.Server.Services;

public interface ISearchApplicationService
{
    Task<SearchResultViewModel> PerformSearch(SearchQueryRequest searchQueryRequest);
}