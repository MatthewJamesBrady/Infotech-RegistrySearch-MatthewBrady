using InfoTech_Data.SearchResultsData;
using Microsoft.EntityFrameworkCore;

namespace InfoTech_Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SearchResultsEntity> SearchResults { get; set; }
}