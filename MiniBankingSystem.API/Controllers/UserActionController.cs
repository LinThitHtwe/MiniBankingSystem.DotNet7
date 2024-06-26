using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBankingSystem.Utils.Helpers;
using System.Net;

namespace MiniBankingSystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserActionController : ControllerBase
    {
        private readonly BankActions _bankActions;

        public UserActionController(BankActions bankActions)
        {
            _bankActions = bankActions;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(BankActionRequest bankActionRequest)
        {
            var bankActionResponse = await _bankActions.Deposit(bankActionRequest);
            var apiResponse = ApiResponseMapper.CreateApiResponse(bankActionResponse, ApiResponseCodes.Success, "Successfully Deposit");
            return Ok(apiResponse);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(BankActionRequest bankActionRequest)
        {
            var bankActionResponse = await _bankActions.Withdraw(bankActionRequest);
            var apiResponse = ApiResponseMapper.CreateApiResponse(bankActionResponse, ApiResponseCodes.Success, "Successfully Withdraw");
            return Ok(apiResponse);
        }
    }
}
