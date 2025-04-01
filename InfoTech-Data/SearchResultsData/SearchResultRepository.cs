using InfoTrack_RegistrySearch_Domain.SearchOutput;
using Microsoft.EntityFrameworkCore;

namespace InfoTrack_Data.SearchResultsData;

public class SearchResultRepository : ISearchResultRepository
{
    private readonly AppDbContext _context;

    private readonly SearchResultsMapper _mapper;

    public SearchResultRepository(AppDbContext context)
    {
        _context = context;
        _mapper = new SearchResultsMapper();
    }

    public async Task<IEnumerable<SearchResults>> GetAllAsync()
    {
        var allSearchResults =  await _context.SearchResults.ToListAsync();
        return allSearchResults.Select(sr => _mapper.ToDomain(sr));
    }

    public async Task<SearchResults> GetByIdAsync(int id)
    {
        var searchResults = await _context.SearchResults.FindAsync(id);
        return _mapper.ToDomain(searchResults ?? throw new InvalidOperationException());
    }

    public async Task AddAsync(SearchResults result)
    {
        var searchResultsEntity = _mapper.ToDto(result);
        _context.SearchResults.Add(searchResultsEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SearchResults result)
    {
        var searchResultsEntity = _mapper.ToDto(result);
        _context.SearchResults.Update(searchResultsEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _context.SearchResults.FindAsync(id);
        if (result != null)
        {
            _context.SearchResults.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Upsert(SearchResults searchResult)
    {
        try
        {
            var existing = await _context.SearchResults.FirstOrDefaultAsync(sr =>
                sr.Url == searchResult.Url.Url.AbsoluteUri &&
                sr.Phrase == searchResult.Phrase.Phrase &&
                sr.SearchEngineUrl == searchResult.SearchEngineUrl);

            if (existing == null)
            {
                var entity = _mapper.ToDto(searchResult);
                _context.SearchResults.Add(entity);
            }
            else
            {
                var entity = _mapper.ToDto(searchResult);
                _context.SearchResults.Update(entity);
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Upsert error: " + ex.Message);
            throw;
        }


        //var existing = await _context.SearchResults.FirstOrDefaultAsync(sr =>
        //    sr.Url == searchResult.Url.Url.AbsoluteUri &&
        //    sr.Phrase == searchResult.Phrase.Phrase &&
        //    sr.SearchEngineUrl == searchResult.SearchEngineUrl);

        //if (existing == null)
        //{
        //    await this.AddAsync(searchResult);
        //}
        //else
        //{
        //    await this.UpdateAsync(searchResult);
        //}
    }
}