using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class DepartmentController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/dept/tree")]
        public ApiArrayResult<DeptTreeQueryResponse> RegisterQuery(DeptTreeQueryRequest request) => this.DoApiArrayResult(
            proxyService.GetDepartmentTree<HModels.HospDeptTreeQueryRequest, HModels.HospDeptTreeQueryResponse, DeptTreeQueryRequest, DeptTreeQueryResponse[]>(
                request,
                req => new HModels.HospDeptTreeQueryRequest
                {
                    deptCode = req.deptCode
                },
                res => res.data?.Select(p => new DeptTreeQueryResponse
                {
                    pCode = p.ParentCode,
                    pName = p.ParentName,
                    depts = p.childrenList?.Select(i => new DeptTreeQueryResponseItem
                    {
                        code = i.DeptCode,
                        name = i.DeptName,
                        simple = i.SimpleName
                    })?.ToArray()
                })?.ToArray()));
    }
}
