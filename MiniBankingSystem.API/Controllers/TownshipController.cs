using MiniBankingSystem.BusinessLogic.Features.Township;

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

        [HttpGet("{townshipCode}")]
        public async Task<IActionResult> GetTownshipByCode(string townshipCode)
        {
            try
            {
                var township = await _townshipService.GetTownshipByCode(townshipCode);
                if (township is null)
                {
                    return NotFound(ApiResponseMapper.CreateApiResponse(new { }, ApiResponseCodes.NotFound));
                }
                var apiResponse = ApiResponseMapper.CreateApiResponse(township);
                return Ok(apiResponse);
            }
            catch (Exception e)
            {

                return StatusCode(500, ApiResponseMapper.CreateApiResponse(e, ApiResponseCodes.InternalServerError, e.Message));
            }
        }
    }
}
