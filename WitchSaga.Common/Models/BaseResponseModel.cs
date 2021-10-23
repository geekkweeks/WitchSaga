using System.Collections.Generic;
using System.Net;

namespace WitchSaga.Common.Models
{
    public class BaseResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public static class BaseResponseModelExtension
    {
        public static BaseResponseModel SetOk(this BaseResponseModel model, string message = null)
        {
            model.ResponseCode = 200;

            if (!string.IsNullOrEmpty(message))
            {
                model.ResponseMessage = message;
            }

            return model;
        }

        public static BaseResponseModel SetError(this BaseResponseModel model, string message = null)
        {
            model.ResponseCode = 500;

            if (!string.IsNullOrEmpty(message))
            {
                model.ResponseMessage = message;
            }

            return model;
        }
    }
}
