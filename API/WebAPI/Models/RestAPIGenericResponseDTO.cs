using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /**
     * This class represents a generic response model for any operation provided by <c>IAPIGenericService</c> class
     */
    /// <summary>
    /// This class represents a generic response model for any operation provided by <c>IAPIGenericService</c> class
    /// </summary>     
    public class RestAPIGenericResponseDTO<R>
    {
        /// <value>Indicate wether request succeeds or failed</value>
        public bool Success { get; set; }
        /// <value>The code for the response</value>
        public string ResponseCode { get; set; }
        /// <value>Entity returned in response to a request</value>
        //[JsonIgnore()]
        public R Entity { get; set; }
        /// <value>Text description for the <code>ResponseCode</code></value>
        public string Message { get; set; }
        /// <value>List of entities returned in response to a request</value>
        //[JsonIgnore]
        public IList<R> Entities { get; set; }

        /// <summary>
        /// This method build a new instance indicating error state
        /// </summary>
        public RestAPIGenericResponseDTO<R> WithError(object errCode, string errMsg)
        {
            Success = false;
            ResponseCode = errCode.ToString();
            Message = errMsg;
            return this;
        }
        public RestAPIGenericResponseDTO<R> WithError(object errCode, string errMsg, R entity)
        {
            Success = false;
            ResponseCode = errCode.ToString();
            Message = errMsg;
            Entity = entity;
            return this;
        }
        /// <summary>
        /// This method build a new instance indicating success state
        /// </summary>
        public RestAPIGenericResponseDTO<R> WithSuccess(object resCode, string msg, R entity)
        {
            Success = true;
            ResponseCode = resCode.ToString();
            Message = msg;
            Entity = entity;

            return this;
        }
        public RestAPIGenericResponseDTO<R> WithSuccess(object resCode, string msg, IList<R> entityList = null)
        {
            Success = true;
            ResponseCode = resCode.ToString();
            Message = msg;
            Entities = entityList;

            return this;
        }
        public RestAPIGenericResponseDTO<R> WithException(Exception ex)
        {
            Success = false;
            ResponseCode = "Exp";
            Message = ex.Message;
            return this;
        }
    }

}
