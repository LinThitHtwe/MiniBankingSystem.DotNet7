using MiniBankingSystem.BusinessLogic.Features.State;
using MiniBankingSystem.BusinessLogic.Features.Township;
using MiniBankingSystem.Constants.Exceptions;

namespace MiniBankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownshipController : ControllerBase
    {
        private readonly TownshipService _townshipService;

        public TownshipController(TownshipService townshipService)
        {
            _townshipService = townshipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTownships()
        {
            var townships = await _townshipService.GetAllTownships();
            var apiResponse = ApiResponseMapper.CreateApiResponse(townships);
            return Ok(apiResponse);
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPaginatedTownships([FromQuery] int currentPageNo = 1, [FromQuery] int itemPerPage = 10)
        {
            var paginatedResponse = await _townshipService.GetPaginatedTownships(currentPageNo, itemPerPage);
            var apiResponse = ApiResponseMapper.CreateApiResponse(paginatedResponse);
            return Ok(apiResponse);
        }

        [HttpGet("State/{stateCode}")]
        public async Task<IActionResult> GetTownshipsByStateCode(string stateCode)
        {
            var townships = await _townshipService.GetTownshipsByStateCode(stateCode);
            var apiResponse = ApiResponseMapper.CreateApiResponse(townships);
            return Ok(apiResponse);
        }

        [HttpGet("{townshipCode}")]
        public async Task<IActionResult> GetTownshipByCode(string townshipCode)
        {
            var township = await _townshipService.GetTownshipByCode(townshipCode) ?? throw new NotFoundException("Township Not Found");
            var apiResponse = ApiResponseMapper.CreateApiResponse(township);
            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTownship(TownshipRequestDTO requestTownship)
        {
            var createdTownship = await _townshipService.CreateTownship(requestTownship);
            var apiResponse = ApiResponseMapper.CreateApiResponse(createdTownship, ApiResponseCodes.Created);
            return Ok(apiResponse);
        }

        [HttpPut("{townshipCode}")]
        public async Task<IActionResult> UpdateTownship(string townshipCode, TownshipUpdateRequestDTO requestTownship)
        {
            var updatedTownship = await _townshipService.UpdateTownship(townshipCode, requestTownship);
            var apiResponse = ApiResponseMapper.CreateApiResponse(updatedTownship, ApiResponseCodes.Success, ApiResponseMessages.SuccessUpdate);
            return Ok(apiResponse);
        }

        [HttpDelete("{townshipCode}")]
        public async Task<IActionResult> DeleteTownship(string townshipCode)
        {
            await _townshipService.DeleteTownship(townshipCode);
            var apiResponse = ApiResponseMapper.CreateApiResponse(new { }, 200, ApiResponseMessages.SuccessDelete);
            return Ok(apiResponse);
        }
    }
}
