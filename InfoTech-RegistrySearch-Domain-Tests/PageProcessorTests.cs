using InfoTech_RegistrySearch_Domain_Tests.Helpers;
using InfoTrack_RegistrySearch_Domain.HtmlParser;
using InfoTrack_RegistrySearch_Domain.HtmlParser.Google;
using InfoTrack_RegistrySearch_Domain.SearchInput;
using Shouldly;

namespace InfoTech_RegistrySearch_Domain_Tests;

public class PageProcessorIntegrationTests
{
    private IPageReader reader;
    private IPageDownloader loader;

    private string url = TestValues.SearchUrl;
    private string phrase = "bbc programmes";

    public PageProcessorIntegrationTests()
    {
        reader = new GooglePageReader();
        loader = new PageDownloader();
    }

    [Fact(Skip = "")]
    public void 
       ProcessPage_WithValidURlAndPhrase_ShouldReturnMatches()
    {
        // Arrange
        var sut = new PageProcessor(reader, loader);
        var query = SearchQuery.Create(url, phrase, SearchEngine.Google);

        // Act
        var results = sut.Process(query);
        var formattedResult = results.ProduceFormattedOutput();

        // Assert
        results.ShouldNotBeNull();
        formattedResult.ShouldBe("0");
    }

    [Fact]
    public void SearchEngineParser_WithProcess_ShouldDownloadPage()
    {
        // Arrange
        var searchEngineParser = new SearchEngineParser();
        var query = SearchQuery.Create(url, phrase, SearchEngine.Google);


        // Act
        searchEngineParser.PerformSearch(query);

        // Assert

    }
}