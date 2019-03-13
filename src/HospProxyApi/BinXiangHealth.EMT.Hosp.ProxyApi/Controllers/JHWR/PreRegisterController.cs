using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class PreRegisterController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/pre/register/do")]
        public ApiResult<PreRegisterDoResponse> PreRegisterDo(PreRegisterDoRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp2011Request, HModels.Hosp2011Response, PreRegisterDoRequest, PreRegisterDoResponse>(
                request,
                req => new HModels.Hosp2011Request
                {
                    bookingNo = req.id,
                    pactCode = req.pactCode
                },
                p => new PreRegisterDoResponse
                {
                    deptname = p.data?.deptname,
                    id = p.data?.hisRegisterId,
                    tradeNo = p.data?.tradeNo,
                    seeNo = p.data?.seeNo,
                    address = p.data?.address
                }));

        [Route("api/v1/pre/cancel")]
        public ApiResult<PreRegisterCancelResponse> PreRegisterCancel(PreRegisterCancelRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp2007Request, HModels.Hosp2007Response, PreRegisterCancelRequest, PreRegisterCancelResponse>(
                request,
                req => new HModels.Hosp2007Request
                {
                    bookingNo = req.id
                },
                res => new PreRegisterCancelResponse
                {
                    state = res.IsSuccess ? 0 : -1
                }));

        [Route("api/v1/pre/register")]
        public ApiResult<PreRegisterResponse> PreRegister(PreRegisterRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp2008Request, HModels.Hosp2008Response, PreRegisterRequest, PreRegisterResponse>(
                request,
                req => new HModels.Hosp2008Request
                {
                    cardNo = req.cardNo,
                    preTime = req.time,
                    realName = req.name,
                    shemaId = req.id
                },
                res => new PreRegisterResponse
                {
                    preNo = res.data?.bookingNo,
                    tradeNo = res.data?.tradeNo
                }));

        [Route("api/v1/pre/list")]
        public ApiArrayResult<PreRegisterListResponse> PreRegisterList(PreRegisterListRequest request) => this.DoApiArrayResult(
            proxyService.GetBookingList<HModels.HospPreRegisterListRequest, HModels.HospPreRegisterListResponse, PreRegisterListRequest, PreRegisterListResponse[]>(
                request,
                req => new HModels.HospPreRegisterListRequest
                {
                    cardNo = req.cardNo
                },
                res => res.data?.ListBooking?.Select(a => new PreRegisterListResponse
                {
                    cardNo = a.cardNo,
                    clinicNo = a.clinicNo,
                    cost = a.total,
                    deptName = a.deptName,
                    doctName = a.docName,
                    doctTitle = a.docTitle,
                    name = a.name,
                    preNo = a.bookingNo,
                    operDate = a.operDate,
                    preRegType = a.bookingType,
                    seeNo = a.seeNo,
                    state = a.state,
                    preRegDate = a.bookingDate
                })?.ToArray()));
    }
}
