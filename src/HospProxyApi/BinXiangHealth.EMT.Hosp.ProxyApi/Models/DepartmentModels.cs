namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// dept tree query request
    /// </summary>
    /// <seealse cref="HOSP.JHWR.HospDeptTreeQueryRequest"/>
    public class DeptTreeQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 科室编码
        /// </summary>
        public string deptCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// 科室列表查询 item
    /// </summary>
    public class DeptTreeQueryResponseItem
    {
        /// <summary>
        /// 二级科室编码
        /// </summary>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// 二级科室
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string simple { get; set; } = string.Empty;
    }

    /// <summary>
    /// dept tree query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospDeptTreeQueryResponseData"/>
    public class DeptTreeQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// 一级科室编码
        /// </summary>
        public string pCode { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string pName { get; set; } = string.Empty;

        /// <summary>
        /// 二级科室列表
        /// </summary>
        public DeptTreeQueryResponseItem[] depts { get; set; } = new DeptTreeQueryResponseItem[] { };
    }
}