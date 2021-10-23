using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WitchSaga.Common.Models
{
    public class DataResponse
    {
        public bool Result { get; set; }

        public IList<string> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public DataResponse()
        {

        }

        public DataResponse(bool result)
            : this()
        {
            Result = result;
            StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
    }

    public class DataResponse<T> : DataResponse
        where T : class
    {
        public T Data { get; set; }

        public DataResponse()
        {

        }

        public DataResponse(bool result)
            : base(result)
        {

        }
    }
}
