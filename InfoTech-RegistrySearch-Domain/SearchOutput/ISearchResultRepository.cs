namespace InfoTech_RegistrySearch_Domain.SearchOutput;

public interface ISearchResultRepository
{
    Task<IEnumerable<SearchResults>> GetAllAsync();
    Task<SearchResults> GetByIdAsync(int id);
    Task AddAsync(SearchResults result);
    Task UpdateAsync(SearchResults result);
    Task DeleteAsync(int id);
}