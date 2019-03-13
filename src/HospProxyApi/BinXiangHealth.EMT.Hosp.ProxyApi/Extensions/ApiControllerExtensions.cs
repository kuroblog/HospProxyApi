using Agebull.ZeroNet.ZeroApi;
using Gboxt.Common.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public static class ApiControllerExtensions
    {
        public static ApiArrayResult<TResult> DoApiArrayResult<TResult>(this ApiController controller, (int state, string message, IEnumerable<TResult> data) result)
        {
            return new ApiArrayResult<TResult>
            {
                Success = result.state == 0,
                ResultData = result.data?.ToList(),
                Status = new OperatorStatus
                {
                    ClientMessage = result.message
                }
            };
        }

        public static ApiResult<TResult> DoApiResult<TResult>(this ApiController controller, (int state, string message, TResult data) result)
        {
            return new ApiResult<TResult>
            {
                Success = result.state == 0,
                ResultData = result.data,
                Status = new OperatorStatus
                {
                    ClientMessage = result.message
                }
            };
        }
    }
}
