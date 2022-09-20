using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    /// <summary>
    /// Represents error information
    /// </summary>
    public class ApiError
    {
        public string Message { get; set; }

        public string Detail { get; set; }

        public ApiError() { }

        public ApiError(string message) : this()
        {
            Message = message;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid parameters.";
            Detail = modelState
                .FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
                .FirstOrDefault().ErrorMessage;
        }
    }
}
