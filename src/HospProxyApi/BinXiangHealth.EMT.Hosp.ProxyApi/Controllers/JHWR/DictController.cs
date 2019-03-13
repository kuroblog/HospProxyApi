using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class DictController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/dict/query")]
        public ApiArrayResult<DictQueryResponse> PreRegisterQuery(DictQueryRequest request) => this.DoApiArrayResult(
            proxyService.DoTrans<HModels.Hosp0000Request, HModels.Hosp0000Response, DictQueryRequest, DictQueryResponse[]>(
                request,
                req => new HModels.Hosp0000Request
                {
                    dicType = req.key,
                    dicCode = req.code,
                    isPre = string.Empty,
                    branchcode = string.Empty
                },
                res => res.data?.Select(p => new DictQueryResponse
                {
                    code = p.code,
                    name = p.name,
                    desc = p.memo
                })?.ToArray()));
    }
}