using System.Collections.Generic;

namespace File.Core.Response.Error
{
    public class ErrorResponse
    {
        public List<ErrorModel> ErrorMessage { get; set; } = new List<ErrorModel>();
    }
}