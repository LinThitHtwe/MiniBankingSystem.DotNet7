using MiniBankingSystem.BusinessLogic.Features.Account;

namespace MiniBankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
                throw new Exception("Accounts");
                var accounts = await _accountService.GetAllAccounts();
                var apiResponse = ApiResponseMapper.CreateApiResponse(accounts);
                return Ok(apiResponse);
        }


        [HttpGet("{accountNo}")]
        public async Task<IActionResult> GetAccountByAccountNo(string accountNo)
        {
            try
            {
                var account = await _accountService.GetAccountByAccountNo(accountNo);
                if(account is null)
                {
                    return NotFound(ApiResponseMapper.CreateApiResponse(new {},ApiResponseCodes.NotFound));
                }
                var apiResponse = ApiResponseMapper.CreateApiResponse(account);
                return Ok(apiResponse);
            }
            catch (Exception e)
            {

                return StatusCode(500, ApiResponseMapper.CreateApiResponse(e, ApiResponseCodes.InternalServerError, e.Message));
            }
        }
    }
}
