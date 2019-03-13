namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// cost list request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4002Request"/>
    public class CostListRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// cost list response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4002ResponseData"/>
    public class CostListResponse : IProxyResponseModel
    {
        /// <summary>
        /// 唯一号
        /// </summary>
        public string id { get; set; } = string.Empty;

        /// <summary>
        /// 处方号
        /// </summary>
        public string recipeNo { get; set; } = string.Empty;

        /// <summary>
        /// 处方内序号
        /// </summary>
        public string recipeSeq { get; set; } = string.Empty;

        /// <summary>
        /// 交易类型
        /// </summary>
        public string transType { get; set; } = string.Empty;

        /// <summary>
        /// 最小费用代码
        /// </summary>
        public string feeCode { get; set; } = string.Empty;

        /// <summary>
        /// 是否是药品
        /// </summary>
        public string drugFlag { get; set; } = string.Empty;

        /// <summary>
        /// 项目编码
        /// </summary>
        public string itemCode { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemName { get; set; } = string.Empty;

        /// <summary>
        /// 数量
        /// </summary>
        public string qty { get; set; } = string.Empty;

        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; } = string.Empty;

        /// <summary>
        /// 单价
        /// </summary>
        public string unitPrice { get; set; } = string.Empty;

        /// <summary>
        /// 总额
        /// </summary>
        public string cost { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生
        /// </summary>
        public string docName { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生所在科室
        /// </summary>
        public string exeDoctDept { get; set; } = string.Empty;

        /// <summary>
        /// 执行科室
        /// </summary>
        public string exeDeptName { get; set; } = string.Empty;

        /// <summary>
        /// 开立时间
        /// </summary>
        public string moDate { get; set; } = string.Empty;

        /// <summary>
        /// 是否收费
        /// </summary>
        public string payFlag { get; set; } = string.Empty;

        /// <summary>
        /// 发票号
        /// </summary>
        public string invoiceNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// cost settle request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4004Request"/>
    public class CostSettleRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// 唯一号 使用 | 分隔
        /// </summary>
        public string keys { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <value>ZB 支付宝|WX 微信|CA 现金|CD 银行卡</value>
        public string source { get; set; } = string.Empty;

        /// <summary>
        /// 总费用
        /// </summary>
        public string totCost { get; set; } = string.Empty;

        /// <summary>
        /// 报销费用
        /// </summary>
        public string pubCost { get; set; } = string.Empty;

        /// <summary>
        /// 个人卡内费用
        /// </summary>
        public string payCost { get; set; } = string.Empty;

        /// <summary>
        /// 自费费用
        /// </summary>
        public string ownCost { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 第三方交易流水号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 处方号|处方内序号,处方号|处方内序号
        /// </summary>
        public string recipeKeys { get; set; } = string.Empty;
    }

    /// <summary>
    /// cost settle response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4004ResponseData"/>
    public class CostSettleResponse : IProxyResponseModel
    {
        /// <summary>
        /// 取药窗口
        /// </summary>
        public string windowNo { get; set; } = string.Empty;

        /// <summary>
        /// 发票号
        /// </summary>
        public string invoiceNo { get; set; } = string.Empty;

        /// <summary>
        /// 发票序号
        /// </summary>
        public string invoiceSeq { get; set; } = string.Empty;

        /// <summary>
        /// 医保卡交易流水号
        /// </summary>
        public string siTradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 余额
        /// </summary>
        public string vancy { get; set; } = string.Empty;

        /// <summary>
        /// 执行科室
        /// </summary>
        public string deptName { get; set; } = string.Empty;

        /// <summary>
        /// 费用详细列表(应该是个类,暂时不用)
        /// </summary>
        public string feeItems { get; set; } = string.Empty;
    }

    /// <summary>
    /// cost pre request
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4003Request"/>
    public class CostPreSettleRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// String 	是	唯一号 多个 | 分隔
        /// </summary>
        public string recipeKey { get; set; } = string.Empty;

        /// <summary>
        /// String	是	就诊人姓名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// String	是	门诊流水号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// String	是	缴费操作员
        /// </summary>
        public string operCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// cost pre response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp4003ResponseData"/>
    public class CostPreSettleResponse : IProxyResponseModel
    {
        /// <summary>
        /// String	是	总费用
        /// </summary>
        public string totCost { get; set; } = string.Empty;

        /// <summary>
        /// String	是	报销费用
        /// </summary>
        public string pubCost { get; set; } = string.Empty;

        /// <summary>
        /// String	是	个人卡内费用
        /// </summary>
        public string payCost { get; set; } = string.Empty;

        /// <summary>
        /// String	是	自费费用
        /// </summary>
        public string ownCost { get; set; } = string.Empty;
    }
}
