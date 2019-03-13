namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// register query request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospRegisterQueryRequest"/>
    public class RegisterQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// register query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.HospRegisterQueryResponseData"/>
    public class RegisterQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// 支付状态
        /// </summary>
        /// <value>1 已支付|2 未支付|3 已取消|4 已失效</value>
        public string state { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string deptName { get; set; } = string.Empty;

        /// <summary>
        /// 预约类型
        /// </summary>
        /// <value>1 专家号|2 普通号</value>
        public string regType { get; set; } = string.Empty;

        /// <summary>
        /// 就诊日期
        /// </summary>
        public string regDate { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string doctName { get; set; } = string.Empty;

        /// <summary>
        /// 医生职称
        /// </summary>
        public string doctTitle { get; set; } = string.Empty;

        /// <summary>
        /// 总费用
        /// </summary>
        public string cost { get; set; } = string.Empty;

        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 提交时间
        /// </summary>
        public string operDate { get; set; } = string.Empty;

        /// <summary>
        /// 看诊序号
        /// </summary>
        public string seeNo { get; set; } = string.Empty;

        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// /// register do request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp3004Request"/>
    public class RegisterDoRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 排班编号
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        /// <value></value>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string deptName { get; set; } = string.Empty;

        /// <summary>
        /// 科室编码
        /// </summary>
        public string deptCode { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string doctName { get; set; } = string.Empty;

        /// <summary>
        /// 医生编码
        /// </summary>
        public string doctCode { get; set; } = string.Empty;

        /// <summary>
        /// 挂号级别编码
        /// </summary>
        public string regLevelCode { get; set; } = string.Empty;

        /// <summary>
        /// 挂号午别编码
        /// </summary>
        public string regNoonCode { get; set; } = string.Empty;

        /// <summary>
        /// 挂号类型
        /// </summary>
        /// <value>PT 普通|ZJ 专家</value>
        public string regType { get; set; } = string.Empty;

        /// <summary>
        /// 挂号日期 yyyy-MM-dd
        /// </summary>
        public string regDate { get; set; } = string.Empty;

        /// <summary>
        /// 挂号时间段 HH:mm
        /// </summary>
        public string regTime { get; set; } = string.Empty;

        /// <summary>
        /// 挂号费用
        /// </summary>
        public string cost { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// register do response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp3004ResponseData"/>
    public class RegisterDoResponse : IProxyResponseModel
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 看诊序号
        /// </summary>
        public string seeNo { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        /// <value></value>
        public string detpName { get; set; } = string.Empty;

        /// <summary>
        /// 科室地址
        /// </summary>
        /// <value></value>
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// HIS 交易流水号
        /// </summary>
        /// <value></value>
        public string tradeNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// register cancel request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp3005Response"/>
    public class RegisterCancelRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string id { get; set; } = string.Empty;
    }

    /// <summary>
    /// register cancel response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp3005ResponseData"/>
    public class RegisterCancelResponse : IProxyResponseModel
    {
        public int state { get; set; } = 0;
    }

    /// <summary>
    /// register callback request
    /// </summary>
    ///<seealso cref="HOSP.JHWR.HospRegCallbackRequest"/>
    public class RegisterCallbackRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// 支付流水号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 第三方订单号
        /// </summary>
        public string thirdNo { get; set; } = string.Empty;

        /// <summary>
        /// 支付方式 (支付必填)ZB 支付宝 WX 微信 CA 现金 CD 银行卡
        /// </summary>
        public string source { get; set; } = string.Empty;

        /// <summary>
        /// 是否支付 0未支付 1账户支付 2已经支付
        /// </summary>
        public string isFee { get; set; } = string.Empty;

        /// <summary>
        /// 支付费用
        /// </summary>
        public string cost { get; set; } = string.Empty;

        /// <summary>
        /// 医保结算参数多个#分隔
        /// </summary>
        public string siInfo { get; set; } = string.Empty;
    }

    /// <summary>
    /// register callback response
    /// </summary>
    ///<seealso cref="HOSP.JHWR.HospRegCallbackResponseData"/>
    public class RegisterCallbackResponse : IProxyResponseModel
    {
        public int state { get; set; } = 0;
    }
}
