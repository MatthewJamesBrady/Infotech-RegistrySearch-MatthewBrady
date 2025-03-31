using InfoTech_RegistrySearch_Domain.SearchOutput;
using Infotech_RegistrySearch_MatthewBrady.Server.Requests;
using Infotech_RegistrySearch_MatthewBrady.Server.Services;
using Infotech_RegistrySearch_MatthewBrady.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infotech_RegistrySearch_MatthewBrady.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchApplicationService _searchApplicationService;

        private readonly ISearchHistoryApplicationService _searchHistoryApplicationService;

        public SearchController(ISearchApplicationService searchApplicationService, ISearchHistoryApplicationService searchHistoryApplicationService)
        {
            _searchApplicationService = searchApplicationService;
            _searchHistoryApplicationService = searchHistoryApplicationService;
        }

        [HttpPost("DoSearch")]
        [ProducesResponseType(typeof(SearchResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchResultViewModel>> DoSearch([FromBody] SearchQueryRequest request)
        {
            try
            {
                var results = await this._searchApplicationService.PerformSearch(request);

                return Ok(results);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }

        }

        [HttpPost("DoBBCSearch")]
        [ProducesResponseType(typeof(SearchResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchResultViewModel>> DoBBCGoogleSearch([FromBody] SearchQueryRequest request)
        {
            try
            {
                var bbcRequest = CreateBBCGoogleSearchQueryRequest();
                var results = await this._searchApplicationService.PerformSearch(bbcRequest);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }

        }

        [HttpPost("DoBingBBCSearch")]
        [ProducesResponseType(typeof(SearchResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchResultViewModel>> DoBBCBingSearch([FromBody] SearchQueryRequest request)
        {
            try
            {
                var bbcRequest = CreateBBCBingSearchQueryRequest();
                var results = await this._searchApplicationService.PerformSearch(bbcRequest);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }

        }

        private SearchQueryRequest CreateBBCGoogleSearchQueryRequest()
        {
            return new SearchQueryRequest
            {
                Url = "https://www.bbc.com",
                Phrase = "BBC",
                Engine = "Google"
            };
        }

        private SearchQueryRequest CreateBBCBingSearchQueryRequest()
        {
            return new SearchQueryRequest
            {
                Url = "https://www.bbc.com",
                Phrase = "BBC",
                Engine = "Bing"
            };
        }

        [HttpPost("DailyHistory")]
        [ProducesResponseType(typeof(SearchResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchResultViewModel>> DailyHistory([FromBody] DailyHistoryQuery request)
        {
            try
            {
                var results = await this._searchHistoryApplicationService.SearchAllDailyHistory();

                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }

        }

        [HttpPost("WeeklyHistory")]
        [ProducesResponseType(typeof(SearchResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SearchWeeklyHistoryViewModel>>> WeeklyHistory([FromBody] DailyHistoryQuery request)
        {
            try
            {
                var results = await this._searchHistoryApplicationService.SearchAllWeeklyHistory();

                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }

        }

    }
}
