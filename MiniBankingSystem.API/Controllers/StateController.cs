using MiniBankingSystem.BusinessLogic.Features.State;

namespace MiniBankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;
        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllState()
        {
            var states = await _stateService.GetAllStates();
            var apiResponse = ApiResponseMapper.CreateApiResponse(states,ApiResponseCodes.Success);
            return Ok(apiResponse);
        }

        [HttpGet("{stateCode}")]
        public async Task<IActionResult> GetStateByStateCode(string stateCode)
        {
            var state = await _stateService.GetStateByStateCode(stateCode);
            if(state is null)
            {
                return NotFound();
            }
            var apiResponse = ApiResponseMapper.CreateApiResponse(state, ApiResponseCodes.Success);
            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateState(StateRequestDTO stateRequest)
        {
            try
            {
                if (stateRequest is null)
                {
                    return BadRequest();
                }
                var createdState = await _stateService.CreateState(stateRequest);
                var apiResponse = ApiResponseMapper.CreateApiResponse(createdState, ApiResponseCodes.Created);
                return Ok(apiResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{stateCode}")]
        public async Task<IActionResult> UpdateState(string stateCode,StateUpdateRequestDTO stateRequest)
        {
            try
            {
                var updatedState = await _stateService.UpdateState(stateCode, stateRequest);
                var apiResponse = ApiResponseMapper.CreateApiResponse(updatedState,200,ApiResponseMessages.SuccessUpdate);
                return Ok(apiResponse);
            }
            catch (Exception e)
            {

                return StatusCode(500, ApiResponseMapper.CreateApiResponse(e, ApiResponseCodes.InternalServerError, e.Message));
            }
        }

        [HttpDelete("{stateCode}")]
        public async Task<IActionResult> DeleteState(string stateCode)
        {
            //try
            //{
                await _stateService.DeleteState(stateCode);
                var apiResponse = ApiResponseMapper.CreateApiResponse(new {}, 200, ApiResponseMessages.SuccessDelete);
                return Ok(apiResponse);
            //}
            //catch (Exception e)
            //{

            //    return StatusCode(500,ApiResponseMapper.CreateApiResponse(e,ApiResponseCodes.InternalServerError,e.Message));
            //}
        }

    }
}
