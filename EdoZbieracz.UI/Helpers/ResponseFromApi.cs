using EdoZbieracz.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public class ResponseFromApi<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public static class ResponseFromApiExtension
    {
        public static ResponseFromApi<int> ConvertApiExceptions(this ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ResponseFromApi<int>()
                {
                    Message = "Validation errors have occured.",
                    ValidationErrors = ex.Response,
                    Success = false
                };
            }
            else if (ex.StatusCode == 404)
            {
                return new ResponseFromApi<int>()
                {
                    Message = "The requested item could not be found.",
                    Success = false
                };
            }
            else
            {
                return new ResponseFromApi<int>()
                {
                    Message = "Something went wrong, please try again.",
                    Success = false
                };
            }
        }


    }
}
