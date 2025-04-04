﻿using InfoTrack_Data.SearchResultsData;
using Microsoft.EntityFrameworkCore;

namespace InfoTrack_Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SearchResultsEntity> SearchResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InfotechSearch;Trusted_Connection=True;");
    }
}