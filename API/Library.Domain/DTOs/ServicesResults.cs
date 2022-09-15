using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTOs
{
    // Fluent interface
    public class ServicesResultsDto
    {
        public bool Success { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }

    }
    public class ServicesResults
    {
        private ServicesResultsDto _results = new ServicesResultsDto(); // Initializes the context

        // set the value for properties
        public ServicesResults Success(bool success=true)
        {
            _results.Success = success;
            return this;
        }

        public ServicesResults ResponseCode(string responseCode)
        {
            _results.ResponseCode = responseCode;
            return this;
        }

        public ServicesResults Message(string message)
        {
            _results.Message = message;
            return this;
        }
        // Prints the data to console
        public ServicesResultsDto Results()
        {
            return _results;
        }
    }
}
