using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBankingSystem.BusinessLogic.Features.Township;
using MiniBankingSystem.BusinessLogic.Features.Transactions;
using MiniBankingSystem.Constants.Exceptions;

namespace MiniBankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionHistories()
        {
            var transactionHistories = await _transactionService.GetAllTransactionHistories();
            var apiResponse = ApiResponseMapper.CreateApiResponse(transactionHistories);
            return Ok(apiResponse);
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPaginatedTransactions([FromQuery] int currentPageNo = 1, [FromQuery] int itemPerPage = 10)
        {
            var paginatedResponse = await _transactionService.GetPaginatedTransactionHistories(currentPageNo, itemPerPage);
            var apiResponse = ApiResponseMapper.CreateApiResponse(paginatedResponse);
            return Ok(apiResponse);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransactionById(int transactionId)
        {
            var transaction = await _transactionService.GetTransactionById(transactionId) ?? throw new NotFoundException("Transaction Not Found");
            var apiResponse = ApiResponseMapper.CreateApiResponse(transaction);
            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionRequestDTO transactionRequest)
        {
            var createdTransaction = await _transactionService.CreateTransaction(transactionRequest);
            var apiResponse = ApiResponseMapper.CreateApiResponse(createdTransaction, 201);
            return Ok(apiResponse);
        }

        [HttpPut("{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(int transactionId,TransactionRequestDTO transactionRequest)
        {
            var updatedTransaction = await _transactionService.UpdateTransaction(transactionId, transactionRequest);
            var apiResponse = ApiResponseMapper.CreateApiResponse(updatedTransaction, 200, ApiResponseMessages.SuccessUpdate);
            return Ok(apiResponse);
        }

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> DeleteTransaction(int transactionId)
        {
            await _transactionService.DeleteTransaction(transactionId);
            return Ok(ApiResponseMapper.CreateApiResponse(new {},200,ApiResponseMessages.SuccessDelete));
        }
    }
}
