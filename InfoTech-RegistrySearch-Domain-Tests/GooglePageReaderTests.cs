using InfoTrack_RegistrySearch_Domain.HtmlParser;
using System.Reflection;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using Shouldly;
using InfoTech_RegistrySearch_Domain_Tests.Helpers;
using InfoTrack_RegistrySearch_Domain.HtmlParser.Google;

namespace InfoTech_RegistrySearch_Domain_Tests
{
    public class GooglePageReaderTests
    {

        public string GoogleLandRegistryText;
       

        public SearchQuery Query { get; set; }

        public GooglePageReaderTests()
        {

            var projectRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            GoogleLandRegistryText = File.ReadAllText(projectRoot + @"\\Samples\\LandRegistrySearchPage.html");

            Query = SearchQuery.Create(TestValues.SearchUrl, TestValues.SearchPhrase, SearchEngine.Google);

        }

        

        [Fact]
        public void DoSearch_WithValidPage_ShouldReturnValidResults()
        {
            // Arrange
            var googlePageReader = new GooglePageReader
            {
                Text = GoogleLandRegistryText
            };

            // Act
            var result = googlePageReader.FindFirstSearchResult(Query);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Read_WithValidPage_ShouldReturnValidResults()
        {
            // Arrange
            var googlePageReader = new GooglePageReader
            {
                Text = GoogleLandRegistryText
            };

            // Act
            var result = googlePageReader.Read(GoogleLandRegistryText, Query);

            // Assert
            
        }
    }
}
