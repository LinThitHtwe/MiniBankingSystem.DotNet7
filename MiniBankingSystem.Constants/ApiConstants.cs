using System;

namespace MiniBankingSystem.Constants
{
    public static class ApiResponseMessages
    {
        public const string SuccessRetrieve = "Successfully Retrieved";
        public const string SuccessCreate = "Successfully Created";
        public const string SuccessUpdate = "Successfully Updated";
        public const string SuccessDelete = "Successfully Deleted";
        public const string BadRequest = "Bad Request. Try Again";
        public const string NotFound = "Data Not Found :(";
        public const string Unauthorized = "Unauthorized!!";
        public const string Forbidden = "Forbidden. No >:(";
        public const string MethodNotAllow = "Wrong Method, You Idiot!";
        public const string Conflict = "Conflict Phyit Twr P XD";
        public const string ServerError = "Server Error :( ,Sorry";
        public const string BadGateway = "BadGateway Pr";
    }

    public static class ApiResponseCodes
    {
        // 2xx: Success
        public const int Success = 200;
        public const int Created = 201;
        public const int Accepted = 202;
        public const int NoContent = 204;

        // 3xx: Redirection
        public const int MovedPermanently = 301;
        public const int Found = 302;
        public const int NotModified = 304;

        // 4xx: Client Error
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int MethodNotAllowed = 405;
        public const int Conflict = 409;
        public const int Gone = 410;
        public const int UnsupportedMediaType = 415;
        public const int UnprocessableEntity = 422;

        // 5xx: Server Error
        public const int InternalServerError = 500;
        public const int NotImplemented = 501;
        public const int BadGateway = 502;
        public const int ServiceUnavailable = 503;
        public const int GatewayTimeout = 504;
    }

}
