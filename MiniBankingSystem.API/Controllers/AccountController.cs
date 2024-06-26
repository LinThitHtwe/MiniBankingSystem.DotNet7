using MiniBankingSystem.BusinessLogic.Features.Account;
using MiniBankingSystem.Constants.Exceptions;

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
            var accounts = await _accountService.GetAllAccounts();
            var apiResponse = ApiResponseMapper.CreateApiResponse(accounts);
            return Ok(apiResponse);
        }


        [HttpGet("{accountNo}")]
        public async Task<IActionResult> GetAccountByAccountNo(string accountNo)
        {
            var account = await _accountService.GetAccountByAccountNo(accountNo) ?? throw new NotFoundException("Account Not Found");
            var apiResponse = ApiResponseMapper.CreateApiResponse(account);
            return Ok(apiResponse);
        }
    }
}
