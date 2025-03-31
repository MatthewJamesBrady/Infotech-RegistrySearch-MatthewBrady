 using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

namespace InfoTech_Search_DataLayer
{
   

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SearchResult> SearchResults { get; set; }
    }

}
