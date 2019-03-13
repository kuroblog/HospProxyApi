using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class RegisterController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/register/do")]
        public ApiResult<RegisterDoResponse> RegisterDo(RegisterDoRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp3004Request, HModels.Hosp3004Response, RegisterDoRequest, RegisterDoResponse>(
                request,
                req => new HModels.Hosp3004Request
                {
                    clinicFee = req.cost,
                    departmentCode = req.deptCode,
                    departmentName = req.deptName,
                    doctorCode = req.doctCode,
                    doctorName = req.doctName,
                    pactCode = req.pactCode,
                    patientCard = req.cardNo,
                    realName = req.name,
                    registrationDate = req.regDate,
                    registrationLevel = req.regLevelCode,
                    registrationNoonCode = req.regNoonCode,
                    registrationTime = req.regTime,
                    registrationType = req.regType,
                    shemaId = req.id
                },
                res => new RegisterDoResponse
                {
                    id = res.data?.hisRegisterId,
                    seeNo = res.data?.seeNo,
                    detpName = res.data?.deptname,
                    address = res.data?.address,
                    tradeNo = res.data?.tradeNo
                }));

        [Route("api/v1/register/cancel")]
        public ApiResult<RegisterCancelResponse> RegisterCancel(RegisterCancelRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp3005Request, HModels.Hosp3005Response, RegisterCancelRequest, RegisterCancelResponse>(
                request,
                req => new HModels.Hosp3005Request
                {
                    registerId = req.id
                },
                res => new RegisterCancelResponse
                {
                    state = res.IsSuccess ? 0 : -1
                }));

        [Route("api/v1/register/query")]
        public ApiArrayResult<RegisterQueryResponse> RegisterQuery(RegisterQueryRequest request) => this.DoApiArrayResult(
            proxyService.GetRegisterList<HModels.HospRegisterQueryRequest, HModels.HospRegisterQueryResponse, RegisterQueryRequest, RegisterQueryResponse[]>(
                request,
                req => new HModels.HospRegisterQueryRequest
                {
                    cardNo = req.cardNo
                },
                res => res.data?.ListRegister?.Select(p => new RegisterQueryResponse
                {
                    cardNo = p.cardNo,
                    clinicNo = p.clinicNo,
                    cost = p.total,
                    deptName = p.deptName,
                    doctName = p.doctName,
                    doctTitle = p.doctTitle,
                    name = p.name,
                    regDate = p.visistDate,
                    regType = p.regType,
                    seeNo = p.seeNo,
                    state = p.state,
                    operDate = p.operDate
                })?.ToArray()));

        [Route("api/v1/register/callback")]
        public ApiResult<RegisterCallbackResponse> RegisterCallback(RegisterCallbackRequest request)
        {
            return this.DoApiResult(
                proxyService.DoTrans<HModels.HospRegCallbackRequest, HModels.HospRegCallbackResponse, RegisterCallbackRequest, RegisterCallbackResponse>(
                    request,
                    p => new HModels.HospRegCallbackRequest
                    {
                        clinicNo = p.clinicNo,
                        feeSource = p.source,
                        isFee = p.isFee,
                        payFee = p.cost,
                        siInfo = p.siInfo,
                        thirdOrderNo = p.thirdNo,
                        tradeNo = p.tradeNo
                    },
                    p => new RegisterCallbackResponse
                    {
                        state = p.data == null ? 0 : p.data.state
                    }));
        }
    }
}
