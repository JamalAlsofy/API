using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    // كان الارجاع القديم قبل ان نستخدم الآلية الجديدة
    public class ResultResponse
    {
        public static object GetSuccess(object msg=null)
        {
            return new { Success = true, ResponseCode = 200, Message = ("Success Operation "+ msg).Trim() };
        }
        public static object GetError(object msg = null)
        {
            return new { Success = false, ResponseCode = 400, Message = ("invalid Operation " + msg).Trim() };
        }
    }
}
