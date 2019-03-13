using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class ReportController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/report/list")]
        public ApiArrayResult<ReportListResponse> ReportList(ReportListRequest request)
        {
            return this.DoApiArrayResult(
                proxyService.DoTrans<HModels.Hosp5001Request, HModels.Hosp5001Response, ReportListRequest, ReportListResponse[]>(
                    request,
                    p => new HModels.Hosp5001Request
                    {
                        beginDate = p.begDate,
                        endDate = p.endDate,
                        patientCard = p.cardNo,
                        realName = p.name
                    },
                    p => p.data?.Select(a => new ReportListResponse
                    {
                        checkType = a.checkType,
                        id = a.queryId,
                        itemName = a.itemName,
                        name = a.realName,
                        status = a.status
                    })?.ToArray()));
        }

        [Route("api/v1/report/query")]
        public ApiResult<ReportQueryResponse> ReportQuery(ReportQueryRequest request)
        {
            return this.DoApiResult(
                proxyService.DoTrans<HModels.HospReportQueryRequest, HModels.HospReportQueryResponse, ReportQueryRequest, ReportQueryResponse>(
                    request,
                    p => new HModels.HospReportQueryRequest
                    {
                        checkType = p.type,
                        queryId = p.id
                    },
                    p => new ReportQueryResponse
                    {
                        checkDate = p.data?.checkDate,
                        conclusion = p.data?.repostResult,
                        name = p.data?.realName,
                        result = p.data?.reportMessage,
                        sex = p.data?.sex,
                        type = p.data?.type
                    }));
        }

        [Route("api/v1/report/detail")]
        public ApiArrayResult<ReportDetailResponse> ReportDetail(ReportDetailRequest request)
        {
            return this.DoApiArrayResult(
                proxyService.DoTrans<HModels.HospReportDetailRequest, HModels.HospReportDetailResponse, ReportDetailRequest, ReportDetailResponse[]>(
                    request,
                    p => new HModels.HospReportDetailRequest
                    {
                        checkType = p.type,
                        queryId = p.id
                    },
                    p => p.data?.Select(a => new ReportDetailResponse
                    {
                        actual = a.realResult,
                        conclusion = a.conclusion,
                        date = a.checkDate,
                        itemName = a.itemName,
                        name = a.realName,
                        reference = a.referprint,
                        sample = a.sample,
                        sex = a.sex,
                        type = a.type
                    })?.ToArray()));
        }
    }
}
