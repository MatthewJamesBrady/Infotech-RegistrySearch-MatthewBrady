using InfoTech_Data;
using InfoTech_Data.SearchResultsData;
using InfoTech_RegistrySearch_Domain.SearchInput;
using InfoTech_RegistrySearch_Domain.SearchOutput;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace InfoTech_Data_Tests
{
    public class TestAppDbContext(DbContextOptions<AppDbContext> options) : AppDbContext(options)
    {
        public DbSet<SearchResultsEntity> SearchResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}");
            
        }
    }

    public class SearchResultRepositoryTests
    {


        private SearchResultRepository sut;

        private TestAppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;
            var context = new TestAppDbContext(options);
            return context;
        }

        public SearchResultRepositoryTests()
        {
            var appContext = CreateInMemoryDbContext();
               sut = new SearchResultRepository(appContext);
        }

        private SearchResults CreateSearchResults()
        {
            var newResult = new SearchResults
            {
                Url = new SearchUrl("http://www.bbc.co.uk"),
                Phrase = new SearchPhrase() { Phrase = "land registry search"},
                SearchEngineUrl = "https://www.google.co.uk/search?num=100&q=land+registry+search",
                RetirevalDate = new DateOnly(2021, 12, 31)
            };
            return newResult;
        }

 
        [Fact(Skip ="")]
        public async Task AddAsync_WithValidSearchResults_ShouldSaveToDB()
        {
            // Arrange
            var searchResultToSave = CreateSearchResults();


            // Act
            await sut.AddAsync(searchResultToSave);
            var results = await sut.GetAllAsync();

            // Assert
            results.Count().ShouldBe(1);
        }

        [Fact(Skip = "")]
        public async Task GetByIdAsync_WithValidId_ShouldReturnSearchResults()
        {
            // Arrange
            var searchResultToSave = CreateSearchResults();
            await sut.AddAsync(searchResultToSave);
            // Act
            var result = await sut.GetByIdAsync(1);
            // Assert
            result.ShouldNotBeNull();
        }

        [Fact(Skip = "")]
        public async Task UpdateAsync_WithValidSearchResults_ShouldUpdateSearchResults()
        {
            // Arrange
            var searchResultToSave = CreateSearchResults();
            await sut.AddAsync(searchResultToSave);
            var result = await sut.GetByIdAsync(1);
            result.Url = new SearchUrl("http://www.bbc.co.uk/news");

            // Act
            await sut.UpdateAsync(result);
            var updatedResult = await sut.GetByIdAsync(1);

            // Assert
            updatedResult.Url.Url.AbsoluteUri.ShouldBe("http://www.bbc.co.uk/news");
        }

    }
}
