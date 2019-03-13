using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class ScheduleController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/schedule/time")]
        public ApiResult<ScheduleTimeResponse> ScheduleTime(ScheduleTimeRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp2004Request, HModels.Hosp2004Response, ScheduleTimeRequest, ScheduleTimeResponse>(
                request,
                req => new HModels.Hosp2004Request
                {
                    shemaId = req.id
                },
                res => new ScheduleTimeResponse
                {
                    times = res.data?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)?.ToArray()
                }));

        [Route("api/v1/schedule/query")]
        public ApiArrayResult<ScheduleQueryResponse> ScheduleQuery(ScheduleQueryRequest request) => this.DoApiArrayResult(
            proxyService.DoTrans<HModels.Hosp2003Request, HModels.Hosp2003Response, ScheduleQueryRequest, ScheduleQueryResponse[]>(
                request,
                req => new HModels.Hosp2003Request
                {
                    beginDate = req.begDate,
                    deptCode = req.deptCode,
                    endDate = req.endDate,
                    isPre = req.isPre
                },
                res => res.data?.Select(p => new ScheduleQueryResponse
                {
                    address = p.ADRESS,
                    begTime = p.BEGIN_TIME,
                    itemCode = p.ITEMCODE,
                    date = p.SEE_DATE,
                    deptCode = p.DEPT_CODE,
                    deptName = p.DEPT_NAME,
                    doctCode = p.DOCT_CODE,
                    doctName = p.DOCT_NAME,
                    endTime = p.END_TIME,
                    id = p.ID,
                    limitMax = p.BOOKING_LMT,
                    noonCode = p.NOONCODE,
                    noonName = p.NOONNAME,
                    regCode = p.REGLEVL_CODE,
                    cost = p.TOT_COST,
                    limitReged = p.TEL_REGED,
                    regName = p.REGLEVL_NAME,
                    regType = p.REGISTRATION_TYPE,
                    sortId = p.SORTID,
                    week = p.WEEK,
                    limitHave = p.HASREG
                })?.ToArray()));
    }
}