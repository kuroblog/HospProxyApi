namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// card query request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp1002Request"/>
    public class CardQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 建档卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string idCard { get; set; } = string.Empty;

        /// <summary>
        /// 建档卡号类型
        /// </summary>
        /// <value>1 物理卡|5 身份证|6 医保卡|7 银行卡</value>
        public string cardType { get; set; } = string.Empty;

        /// <summary>
        /// 查询方式
        /// </summary>
        /// <value>0 自费|1 物理卡号</value>
        public string queryMode { get; set; } = string.Empty;
    }

    /// <summary>
    /// card query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp1002ResponseData"/>
    public class CardQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; } = string.Empty;

        /// <summary>
        /// 生日
        /// </summary>
        public string birthday { get; set; } = string.Empty;

        /// <summary>
        /// 联系人
        /// </summary>
        public string linkman { get; set; } = string.Empty;

        /// <summary>
        /// 联系人地址
        /// </summary>
        public string linkmanAddr { get; set; } = string.Empty;

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string linkmanTel { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string idNo { get; set; }
    }
}
