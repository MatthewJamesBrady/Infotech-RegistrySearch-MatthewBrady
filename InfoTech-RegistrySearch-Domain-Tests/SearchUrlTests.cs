using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrack_RegistrySearch_Domain.HtmlParser;
using InfoTrack_RegistrySearch_Domain.HtmlParser.Google;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using Shouldly;

namespace InfoTech_RegistrySearch_Domain_Tests
{
    public class GoogleSearchEngineUrlGeneratorTests
    {
        [Fact]
        public void GenerateUrl_WithValidPhraseAndSearchUrl_ShouldGenerateValidUrl()
        {
            // Arrange
            const string expectedResult = "https://www.google.co.uk/search?num=100&q=land+registry+search";
            var sut = new GoogleSearchEngineUrlGenerator();

            const string url = "https://www.gov.uk/government/organisations/land-registry";

            var query = SearchQuery.Create(url, "land registry search", SearchEngine.Google);

            // Act
            var result = sut.GenerateUrl(query);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(expectedResult, "There wasn't a match");

        }
    }
}
