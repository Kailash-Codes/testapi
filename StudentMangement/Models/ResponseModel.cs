using System;

namespace StudentMangement.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public string DeveloperErrorMessage { get; set; }

        public ResponseModel(bool success, string message, T data, string errorMessage = null, string developerErrorMessage = null)
        {
            Success = success;
            Message = message;
            Data = data;
            ErrorMessage = errorMessage;
            DeveloperErrorMessage = developerErrorMessage;
        }
    }
}
