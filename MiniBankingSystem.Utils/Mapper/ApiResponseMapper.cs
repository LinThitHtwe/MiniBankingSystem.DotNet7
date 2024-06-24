using MiniBankingSystem.Constants;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Mapper
{
    public class ApiResponseMapper
    {
        public static ApiResponse CreateApiResponse(object responseData, int statusCode = 200, string message = "")
        {
            message ??= GenerateResponseMessages(statusCode);

            return new ApiResponse
            {
                message = message,
                statusCode = statusCode,
                responseData = responseData,
                time = DateTime.Now,
            };
        }

        private static string GenerateResponseMessages(int statusCode)
        {
            return statusCode switch
            {
                ApiResponseCodes.Success => ApiResponseMessages.SuccessRetrieve,
                ApiResponseCodes.Created => ApiResponseMessages.SuccessCreate,
                ApiResponseCodes.Accepted => ApiResponseMessages.SuccessRetrieve,
                ApiResponseCodes.NoContent => ApiResponseMessages.SuccessRetrieve,
                ApiResponseCodes.BadRequest => ApiResponseMessages.BadRequest,
                ApiResponseCodes.Unauthorized => ApiResponseMessages.Unauthorized,
                ApiResponseCodes.Forbidden => ApiResponseMessages.Forbidden,
                ApiResponseCodes.NotFound => ApiResponseMessages.NotFound,
                ApiResponseCodes.MethodNotAllowed => ApiResponseMessages.MethodNotAllow,
                ApiResponseCodes.Conflict => ApiResponseMessages.Conflict,
                ApiResponseCodes.InternalServerError => ApiResponseMessages.ServerError,
                ApiResponseCodes.BadGateway => ApiResponseMessages.BadGateway,
                _ => "Unknown Status Code"
            };
        }


    }
}
