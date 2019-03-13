namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// report list request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp5001Request"/>
    public class ReportListRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 就诊人卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 开始时间
        /// </summary>
        public string begDate { get; set; } = string.Empty;

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; } = string.Empty;
    }

    /// <summary>
    /// report list response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp5001Response"/>
    public class ReportListResponse : IProxyResponseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemName { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 1-检验 2-检查
        /// </summary>
        public string checkType { get; set; } = string.Empty;

        /// <summary>
        /// 0-检查中1-检查完成
        /// </summary>
        public string status { get; set; } = string.Empty;
    }

    /// <summary>
    /// report query request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospReportQueryRequest"/>
    public class ReportQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 1-检验 2-检查
        /// </summary>
        public string type { get; set; } = string.Empty;
    }

    /// <summary>
    /// report query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospReportQueryResponseData"/>
    public class ReportQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; } = string.Empty;

        /// <summary>
        /// 检查日期
        /// </summary>
        public string checkDate { get; set; } = string.Empty;

        /// <summary>
        /// 报告类型
        /// </summary>
        public string type { get; set; } = string.Empty;

        /// <summary>
        /// 检查所见
        /// </summary>
        public string result { get; set; } = string.Empty;

        /// <summary>
        /// 检查结论
        /// </summary>
        public string conclusion { get; set; } = string.Empty;
    }

    /// <summary>
    /// report detail request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospReportDetailRequest"/>
    public class ReportDetailRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 1-检验 2-检查
        /// </summary>
        public string type { get; set; } = string.Empty;
    }

    /// <summary>
    /// report detail response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospReportDetailResponseData"/>
    public class ReportDetailResponse : IProxyResponseModel
    {
        /// <summary>
        /// 报告名称
        /// </summary>
        public string itemName { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; } = string.Empty;

        /// <summary>
        /// 检查日期
        /// </summary>
        public string date { get; set; } = string.Empty;

        /// <summary>
        /// 报告类型
        /// </summary>
        public string type { get; set; } = string.Empty;

        /// <summary>
        /// 样本
        /// </summary>
        public string sample { get; set; } = string.Empty;

        /// <summary>
        /// 实际值
        /// </summary>
        public string actual { get; set; } = string.Empty;

        /// <summary>
        /// 参考值
        /// </summary>
        public string reference { get; set; } = string.Empty;

        /// <summary>
        /// 结论
        /// </summary>
        public string conclusion { get; set; } = string.Empty;
    }
}
