using System;

namespace PriceQuoteForValueLabs.Controllers
{
    public abstract class Response
    {
        /// <summary>
        /// State of the request. Possible values are enumerated under StatusNames.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Message to be displayed with the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status names
        /// </summary>
        public static class StatusNames
        {
            /// <summary>
            /// The request was performed without errors.
            /// </summary>
            public const string Success = "success";

            /// <summary>
            /// There were errors during the execution of the request.
            /// </summary>
            public const string Error = "error";
        }
    }

    /// <summary>
    /// Response wrapper that provides additional information of the status of the server on the response.
    /// </summary>
    /// <typeparam name="T">Data type to be wrapped into the response.</typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// Response data to be used by the client.
        /// </summary>
        public T Data { get; set; }

        public static Response<T> CreateSuccessResponse(T data)
        {
            return new Response<T>
            {
                Status = StatusNames.Success,
                Data = data
            };
        }

        public static Response<T> CreateErrorResponse(Exception ex)
        {
            return new Response<T>
            {
                Status = StatusNames.Error,
                Message = ex.Message
            };
        }
    }
}