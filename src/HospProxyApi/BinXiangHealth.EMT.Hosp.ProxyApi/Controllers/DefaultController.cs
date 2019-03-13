using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Services;
using System;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly ITestService tService = Agebull.Common.Ioc.IocHelper.Create<ITestService>();

        [Route("api/default/hello")]
        public Gboxt.Common.DataModel.ApiResult Hello()
        {
            return new Gboxt.Common.DataModel.ApiResult<string>
            {
                ResultData = tService.Hello
            };
        }
    }
}
