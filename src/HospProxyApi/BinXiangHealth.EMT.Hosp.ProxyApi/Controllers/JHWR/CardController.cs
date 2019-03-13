using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class CardController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/card/query")]
        public ApiResult<CardQueryResponse> CardQuery(CardQueryRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp1002Request, HModels.Hosp1002Response, CardQueryRequest, CardQueryResponse>(
                request,
                req => new HModels.Hosp1002Request
                {
                    idCard = req.idCard,
                    mCardNo = req.cardNo,
                    mType = req.cardType,
                    queryType = req.queryMode,
                    realName = req.name
                },
                res => new CardQueryResponse
                {
                    birthday = res.data?.birthday,
                    cardNo = res.data?.cardNo,
                    linkmanAddr = res.data?.linkman_add,
                    linkman = res.data?.linkman_name,
                    linkmanTel = res.data?.linkman_tel,
                    name = res.data?.name,
                    pactCode = res.data?.pactCode,
                    sex = res.data?.sex,
                    idNo = res.data?.idno
                }));
    }
}
