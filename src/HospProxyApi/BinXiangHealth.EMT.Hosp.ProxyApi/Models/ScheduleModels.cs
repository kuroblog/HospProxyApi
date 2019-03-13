namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// schedule time request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp2004Request"/>
    public class ScheduleTimeRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 排班编号
        /// </summary>
        public string id { get; set; }
    }

    /// <summary>
    /// schedule time response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp2004Response"/>
    public class ScheduleTimeResponse : IProxyResponseModel
    {
        /// <summary>
        /// 时间点信息
        /// </summary>
        public string[] times { get; set; }
    }

    /// <summary>
    /// schedule query request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp2003Request"/>
    public class ScheduleQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 开始时间 yyyy-MM-dd
        /// </summary>
        public string begDate { get; set; } = string.Empty;

        /// <summary>
        /// 结束时间 yyyy-MM-dd
        /// </summary>
        public string endDate { get; set; } = string.Empty;

        /// <summary>
        /// 科室编码
        /// </summary>
        public string deptCode { get; set; } = string.Empty;

        /// <summary>
        /// 是否预约
        /// </summary>
        /// <value>0 不预约|1 预约</value>
        public string isPre { get; set; } = string.Empty;
    }

    /// <summary>
    /// schedule query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp2003ResponseData"/>
    public class ScheduleQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// 排班 Id
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 看诊日期
        /// </summary>
        public string date { get; set; } = string.Empty;

        /// <summary>
        /// 星期几
        /// </summary>
        public string week { get; set; } = string.Empty;

        /// <summary>
        /// 午别编码
        /// </summary>
        public string noonCode { get; set; } = string.Empty;

        /// <summary>
        /// 午别
        /// </summary>
        public string noonName { get; set; } = string.Empty;

        /// <summary>
        /// 看诊时间 开始
        /// </summary>
        public string begTime { get; set; } = string.Empty;

        /// <summary>
        /// 看诊时间 结束
        /// </summary>
        public string endTime { get; set; } = string.Empty;

        /// <summary>
        /// 科室编码
        /// </summary>
        public string deptCode { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string deptName { get; set; } = string.Empty;

        /// <summary>
        /// 医生编码
        /// </summary>
        public string doctCode { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string doctName { get; set; } = string.Empty;

        /// <summary>
        /// 预约最大数
        /// </summary>
        /// <value></value>
        public string limitMax { get; set; } = string.Empty;

        /// <summary>
        /// 已预约数
        /// </summary>
        public string limitReged { get; set; } = string.Empty;

        /// <summary>
        /// 挂号等级编码
        /// </summary>
        public string regCode { get; set; } = string.Empty;

        /// <summary>
        /// 挂号等级
        /// </summary>
        public string regName { get; set; } = string.Empty;

        /// <summary>
        /// 挂号金额
        /// </summary>
        public string cost { get; set; } = string.Empty;

        /// <summary>
        /// 科室地址
        /// </summary>
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// 挂号类型
        /// </summary>
        /// <value>PT 普通|ZJ 专家</value>
        public string regType { get; set; } = string.Empty;

        /// <summary>
        /// HIS 项目编码 对应收费项目(根据此字段1005查询医保中心对应的项目编码和医院的自付比率)
        /// </summary>
        public string itemCode { get; set; } = string.Empty;

        /// <summary>
        /// 排序 Id
        /// </summary>
        public string sortId { get; set; } = string.Empty;

        /// <summary>
        /// 剩余预约数
        /// </summary>
        /// <value></value>
        public string limitHave { get; set; } = string.Empty;
    }
}
