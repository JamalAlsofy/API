using Library.Domain.DTOs;
using Library.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Utils
{
    public class ServicesResultsDRY
    {
        public static ServicesResultsDto GetSuccess(string message=null)
        {
            return GetResult(true, ResultsTypes.Done, message);
            //var tuple = GetCodeMessage(ResultsTypes.Done);
            //return new ServicesResults().Success(true).ResponseCode(tuple.Item1).Message(GetMerge(tuple.Item2,message)).Results();
        }
        public static ServicesResultsDto GetError(ResultsTypes resultType,string message = null)
        {
            return GetResult(false, resultType, message);
        }
        public static ServicesResultsDto GetException()
        {
            return GetResult(false, ResultsTypes.Exception);
        }
        private static ServicesResultsDto GetResult(bool success,ResultsTypes resultType, string message = null)
        {
            var tuple = GetCodeMessage(resultType);
            return new ServicesResults().Success(success).ResponseCode(tuple.Item1).Message(GetMerge(tuple.Item2, message)).Results();
        }
        private static string GetMessage(ResultsTypes resultType)
        {
            return ResultsCodes.GetMessage(resultType);
        }
        private static string GetMessage(ResultsTypes resultType, string message)
        {
            return ResultsCodes.GetMessage(resultType)+" : "+ message;
        }
        private static string GetMerge(string message, string message2)
        {
            if (string.IsNullOrWhiteSpace(message2))
                return message;
            return string.Concat(message + " : " + message2);
        }
        private static Tuple<string, string> GetCodeMessage(ResultsTypes resultType)
        {
            return ResultsCodes.GetCodeMessage(resultType);
        }
    }
}
