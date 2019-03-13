using Newtonsoft.Json;
using System;
using System.Linq;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR
{
    public abstract class HospRequestModelBase : IHospProxyRequestModel//<(string code, string json)>
    {
        public virtual (string code, string json) ConvertToHospRequest()
        {
            var attr = GetType().GetCustomAttributes(typeof(HospTransferCodeAttribute), false).FirstOrDefault() as HospTransferCodeAttribute;
            var code = attr == null ? string.Empty : attr.TransferCode;
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return (code, json);
        }
    }

    public abstract class HospResponseModelBase<TData> : IHospProxyResponseModel
    {
        public virtual string result { get; set; } = string.Empty;

        public virtual string message { get; set; } = string.Empty;

        public virtual string funName { get; set; } = string.Empty;

        public virtual string outString { get; set; } = string.Empty;

        public virtual TData data { get; set; } = default(TData);

        public virtual bool IsSuccess => GetResponseCode() == 0;

        public virtual string GetResponseMessage()
        {
            return message;
        }

        public int GetResponseCode()
        {
            return string.Compare(result, "success", true);
        }
    }

    #region  预约列表查询
    /// <summary>
    /// 预约列表查询 入参
    /// </summary>
    [HospTransferCode("")]
    public class HospPreRegisterListRequest : HospRequestModelBase
    {
        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;
    }

    public class HospPreRegisterListResponseItem
    {
        /// <summary>
        /// 预约状态
        /// </summary>
        /// <value>0 已取消|1 正常|2 预约转挂号</value>
        public string state { get; set; } = string.Empty;

        /// <summary>
        /// 科室名称
        /// </summary>
        public string deptName { get; set; } = string.Empty;

        /// <summary>
        /// 预约类型
        /// </summary>
        /// <value>ZJ 专家号|PT 普通号</value>
        public string bookingType { get; set; } = string.Empty;

        /// <summary>
        /// 预约日期
        /// </summary>
        public string bookingDate { get; set; } = string.Empty;

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string docName { get; set; } = string.Empty;

        /// <summary>
        /// 医生职称
        /// </summary>
        public string docTitle { get; set; } = string.Empty;

        /// <summary>
        /// 总费用
        /// </summary>
        public string total { get; set; } = string.Empty;

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
        /// 预约唯一号
        /// </summary>
        public string bookingNo { get; set; } = string.Empty;

        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// 预约列表查询 data
    /// </summary>
    public class HospPreRegisterListResponseData
    {
        public HospPreRegisterListResponseItem[] ListBooking { get; set; }
    }

    /// <summary>
    /// 预约列表查询 返参
    /// </summary>
    public class HospPreRegisterListResponse : HospResponseModelBase<HospPreRegisterListResponseData> { }
    #endregion

    #region 挂号列表查询
    /// <summary>
    /// 挂号列表查询 入参
    /// </summary>
    [HospTransferCode("")]
    public class HospRegisterQueryRequest : HospRequestModelBase
    {
        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;
    }

    public class HospRegisterQueryResponseItem
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
        public string visistDate { get; set; } = string.Empty;

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
        public string total { get; set; } = string.Empty;

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
    /// 挂号列表查询 data
    /// </summary>
    public class HospRegisterQueryResponseData
    {
        public HospRegisterQueryResponseItem[] ListRegister { get; set; }
    }

    /// <summary>
    /// 挂号列表查询 返参
    /// </summary>
    public class HospRegisterQueryResponse : HospResponseModelBase<HospRegisterQueryResponseData> { }
    #endregion

    #region 科室列表查询
    /// <summary>
    /// 科室列表查询 入参
    /// </summary>
    [HospTransferCode("")]
    public class HospDeptTreeQueryRequest : HospRequestModelBase
    {
        /// <summary>
        /// 科室编码
        /// </summary>
        public string deptCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// 科室列表查询 data
    /// </summary>
    public class HospDeptTreeQueryResponseData
    {
        /// <summary>
        /// 一级科室编码
        /// </summary>
        public string ParentCode { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string ParentName { get; set; } = string.Empty;

        /// <summary>
        /// 二级科室列表
        /// </summary>
        public HospDeptTreeQueryResponseItem[] childrenList { get; set; } = new HospDeptTreeQueryResponseItem[] { };
    }

    /// <summary>
    /// 科室列表查询 item
    /// </summary>
    public class HospDeptTreeQueryResponseItem
    {
        /// <summary>
        /// 二级科室编码
        /// </summary>
        public string DeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 二级科室
        /// </summary>
        public string DeptName { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string SimpleName { get; set; } = string.Empty;
    }

    /// <summary>
    /// 科室列表查询 返参
    /// </summary>
    public class HospDeptTreeQueryResponse : HospResponseModelBase<HospDeptTreeQueryResponseData[]> { }
    #endregion

    #region 0000
    /// <summary>
    /// 0000 数据字典查询 入参
    /// </summary>
    [HospTransferCode("0000")]
    public class Hosp0000Request : HospRequestModelBase
    {
        /// <summary>
        /// 字典类型
        /// </summary>
        /// <value>EMPLOYEE|DEPARTMENT|REGLEVEL|PACTUNITINFO|NOON|PAYKIND</value>
        public string dicType { get; set; } = string.Empty;

        /// <summary>
        /// 字典编码
        /// </summary>
        /// <value></value>
        public string dicCode { get; set; } = string.Empty;

        /// <summary>
        /// 字典类型为 EMPLOYEE 时使用
        /// </summary>
        /// <value>0 挂号|1 预约</value>
        public string isPre { get; set; } = string.Empty;

        /// <summary>
        /// 分院区
        /// </summary>
        /// <value>01 广州路|02 河西</value>
        public string branchcode { get; set; } = string.Empty;
    }

    /// <summary>
    /// 0000 data
    /// </summary>
    public class Hosp0000ResponseData
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <value></value>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        /// <value></value>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string spellCode { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string wbCode { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        /// <value></value>
        public string memo { get; set; } = string.Empty;
    }

    /// <summary>
    /// 0000 数据字典查询 返参
    /// </summary>
    public class Hosp0000Response : HospResponseModelBase<Hosp0000ResponseData[]> { }
    #endregion

    #region 1002
    /// <summary>
    /// 1002 患者卡号查询 入参
    /// </summary>
    [HospTransferCode("1002")]
    public class Hosp1002Request : HospRequestModelBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 建档卡号
        /// </summary>
        public string mCardNo { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string idCard { get; set; } = string.Empty;

        /// <summary>
        /// 建档卡号类型
        /// </summary>
        /// <value>1 物理卡|5 身份证|6 医保卡|7 银行卡</value>
        public string mType { get; set; } = string.Empty;

        /// <summary>
        /// 查询方式
        /// </summary>
        /// <value>0 自费|1 物理卡号</value>
        public string queryType { get; set; } = string.Empty;
    }

    /// <summary>
    /// 1002 data
    /// </summary>
    public class Hosp1002ResponseData
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
        /// unknown
        /// </summary>
        public string vacancy { get; set; } = string.Empty;

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
        public string linkman_name { get; set; } = string.Empty;

        /// <summary>
        /// 联系人地址
        /// </summary>
        public string linkman_add { get; set; } = string.Empty;

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string linkman_tel { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string bingliCost { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string idno { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string idno2 { get; set; } = string.Empty;
    }

    /// <summary>
    /// 1002 患者卡号查询 返参
    /// </summary>
    public class Hosp1002Response : HospResponseModelBase<Hosp1002ResponseData> { }
    #endregion

    #region 2003
    /// <summary>
    /// 2003 排班查询 入参
    /// </summary>
    [HospTransferCode("2003")]
    public class Hosp2003Request : HospRequestModelBase
    {
        /// <summary>
        /// 开始时间 yyyy-MM-dd
        /// </summary>
        public string beginDate { get; set; } = string.Empty;

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
    /// 2003 data
    /// </summary>
    public class Hosp2003ResponseData
    {
        /// <summary>
        /// 排班ID
        /// </summary>
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// 看诊日期
        /// </summary>
        public string SEE_DATE { get; set; } = string.Empty;

        /// <summary>
        /// 星期几
        /// </summary>
        public string WEEK { get; set; } = string.Empty;

        /// <summary>
        /// 午别编码
        /// </summary>
        public string NOONCODE { get; set; } = string.Empty;

        /// <summary>
        /// 午别
        /// </summary>
        public string NOONNAME { get; set; } = string.Empty;

        /// <summary>
        /// 看诊时间 开始
        /// </summary>
        public string BEGIN_TIME { get; set; } = string.Empty;

        /// <summary>
        /// 看诊时间 结束
        /// </summary>
        public string END_TIME { get; set; } = string.Empty;

        /// <summary>
        /// 科室编码
        /// </summary>
        public string DEPT_CODE { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string DEPT_NAME { get; set; } = string.Empty;

        /// <summary>
        /// 医生编码
        /// </summary>
        public string DOCT_CODE { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string DOCT_NAME { get; set; } = string.Empty;

        /// <summary>
        /// 预约最大数
        /// </summary>
        /// <value></value>
        public string BOOKING_LMT { get; set; } = string.Empty;

        /// <summary>
        /// 已预约数
        /// </summary>
        public string TEL_REGED { get; set; } = string.Empty;

        /// <summary>
        /// 挂号等级
        /// </summary>
        public string REGLEVL_CODE { get; set; } = string.Empty;

        /// <summary>
        /// 挂号描述
        /// </summary>
        public string REGLEVL_NAME { get; set; } = string.Empty;

        /// <summary>
        /// 挂号金额
        /// </summary>
        public string TOT_COST { get; set; } = string.Empty;

        /// <summary>
        /// 科室地址
        /// </summary>
        public string ADRESS { get; set; } = string.Empty;

        /// <summary>
        /// 挂号类型
        /// </summary>
        /// <value>PT 普通|ZJ 专家</value>
        public string REGISTRATION_TYPE { get; set; } = string.Empty;

        /// <summary>
        /// HIS 项目编码 对应收费项目(根据此字段1005查询医保中心对应的项目编码和医院的自付比率)
        /// </summary>
        public string ITEMCODE { get; set; } = string.Empty;

        /// <summary>
        /// 排序 ID
        /// </summary>
        public string SORTID { get; set; } = string.Empty;

        /// <summary>
        /// 剩余预约数
        /// </summary>
        public string HASREG { get; set; } = string.Empty;
    }

    /// <summary>
    /// 2003 排班查询 返参
    /// </summary>
    public class Hosp2003Response : HospResponseModelBase<Hosp2003ResponseData[]> { }
    #endregion

    #region 2004
    /// <summary>
    /// 2004 获取预约时间点 入参
    /// </summary>
    [HospTransferCode("2004")]
    public class Hosp2004Request : HospRequestModelBase
    {
        /// <summary>
        /// 排班编号
        /// </summary>
        public string shemaId { get; set; } = string.Empty;
    }

    // 2004 data

    /// <summary>
    /// 2004 获取预约时间点 返参
    /// </summary>
    public class Hosp2004Response : HospResponseModelBase<string> { }
    #endregion

    #region 2007
    /// <summary>
    /// 2007 预约取消 入参
    /// </summary>
    [HospTransferCode("2007")]
    public class Hosp2007Request : HospRequestModelBase
    {
        /// <summary>
        /// String	是	预约唯一号
        /// </summary>
        public string bookingNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// 2007 data
    /// </summary>
    public class Hosp2007ResponseData { }

    /// <summary>
    /// 2007 预约取消 返参
    /// </summary>
    public class Hosp2007Response : HospResponseModelBase<Hosp2007ResponseData> { }
    #endregion

    #region 2008
    /// <summary>
    /// 2008 预约 入参
    /// </summary>
    [HospTransferCode("2008")]
    public class Hosp2008Request : HospRequestModelBase
    {
        /// <summary>
        /// 排班编号
        /// </summary>
        public string shemaId { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 10位就诊卡号
        /// </summary>
        public string cardNo { get; set; } = string.Empty;

        /// <summary>
        /// 预约时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string preTime { get; set; } = string.Empty;

        /// <summary>
        /// 是否支付 0 未支付 1 已支付
        /// </summary>
        public string isCharge { get; set; } = "0";
    }

    /// <summary>
    /// 2008 data
    /// </summary>
    public class Hosp2008ResponseData
    {
        /// <summary>
        /// 预约唯一号
        /// </summary>
        public string bookingNo { get; set; } = string.Empty;

        /// <summary>
        /// unknown 
        /// </summary>
        public string hisSubscriptionsNo { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// 2008 预约 返参
    /// </summary>
    public class Hosp2008Response : HospResponseModelBase<Hosp2008ResponseData> { }
    #endregion

    #region 2011
    /// <summary>
    /// 2011 预约取号 入参
    /// </summary>
    [HospTransferCode("2011")]
    public class Hosp2011Request : HospRequestModelBase
    {
        /// <summary>
        /// 预约唯一号
        /// </summary>
        public string bookingNo { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 操作编码 由 HIS 提供
        /// </summary>
        public string operCode { get; set; } = Startup.OperCode;
    }

    /// <summary>
    /// 2011 data
    /// </summary>
    public class Hosp2011ResponseData
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string hisRegisterId { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string registerId { get; set; } = string.Empty;

        /// <summary>
        /// HIS 交易发票号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 余额
        /// </summary>
        public string vancy { get; set; } = string.Empty;

        /// <summary>
        /// 看诊序号
        /// </summary>
        public string seeNo { get; set; } = string.Empty;

        /// <summary>
        /// 科室地址
        /// </summary>
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string deptname { get; set; } = string.Empty;
    }

    /// <summary>
    /// 2011 预约取号 返参
    /// </summary>
    public class Hosp2011Response : HospResponseModelBase<Hosp2011ResponseData> { }
    #endregion

    #region 3004
    /// <summary>
    /// 3004 挂号 入参
    /// </summary>
    [HospTransferCode("3004")]
    public class Hosp3004Request : HospRequestModelBase
    {
        /// <summary>
        /// 排班编号 专家号必填
        /// </summary>
        public string shemaId { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 建档卡号
        /// </summary>
        public string mCardNo { get; set; } = string.Empty;

        /// <summary>
        /// 10 位就诊卡号
        /// </summary>
        /// <value></value>
        public string patientCard { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        public string departmentName { get; set; } = string.Empty;

        /// <summary>
        /// 科室编码
        /// </summary>
        public string departmentCode { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string doctorName { get; set; } = string.Empty;

        /// <summary>
        /// 医生编码
        /// </summary>
        public string doctorCode { get; set; } = string.Empty;

        /// <summary>
        /// 挂号级别
        /// </summary>
        public string registrationLevel { get; set; } = string.Empty;

        /// <summary>
        /// 挂号午别编码
        /// </summary>
        public string registrationNoonCode { get; set; } = string.Empty;

        /// <summary>
        /// 门诊类型
        /// </summary>
        /// <value>PT 普通门诊|ZJ 专家门诊</value>
        public string registrationType { get; set; } = string.Empty;

        /// <summary>
        /// 挂号日期 yyyy-MM-dd
        /// </summary>
        public string registrationDate { get; set; } = string.Empty;

        /// <summary>
        /// 挂号时间段 HH:mm
        /// </summary>
        public string registrationTime { get; set; } = string.Empty;

        /// <summary>
        /// 挂号费用
        /// </summary>
        public string clinicFee { get; set; } = "0";

        /// <summary>
        /// 总费用
        /// </summary>
        /// <value></value>
        public string totCost { get; set; } = string.Empty;

        /// <summary>
        /// 报销费用
        /// </summary>
        /// <value></value>
        public string pubCost { get; set; } = string.Empty;

        /// <summary>
        /// 个人卡内费用
        /// </summary>
        /// <value></value>
        public string payCost { get; set; } = string.Empty;

        /// <summary>
        /// 自费费用
        /// </summary>
        /// <value></value>
        public string ownCost { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 自助机编号
        /// </summary>
        public string termId { get; set; } = string.Empty;

        /// <summary>
        /// 操作编码 由 HIS 提供
        /// </summary>
        public string operCode { get; set; } = Startup.OperCode;

        /// <summary>
        /// 是否支付 实际支付状态以 clinicFee 为准
        /// </summary>
        /// <value>0 未支付|1 账户支付|2 已支付</value>
        public string isFee { get; set; } = "0";

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <value>ZB 支付宝|WX 微信|CA 现金|CD 银行卡</value>
        public string feeSource { get; set; } = string.Empty;

        /// <summary>
        /// 第三方交易流水号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 医保结算参数 使用 # 分隔
        /// </summary>
        public string siInfo { get; set; } = string.Empty;

        /// <summary>
        /// 医保卡信息
        /// </summary>
        public string siCardInfo { get; set; } = string.Empty;

        /// <summary>
        /// 医保卡余额
        /// </summary>
        public string siBalanceInfo { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string siReg { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string siRegInfo { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string siCode { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        /// <value></value>
        public string idCard { get; set; } = string.Empty;

        /// <summary>
        /// 支付标识
        /// </summary>
        /// <value>>0 未支付<br></value>
        /// <remark>
        /// his 业务逻辑
        /// 为 0 时会在待缴费列表中增加待缴费的挂号项目
        /// 其它时会走原来的逻辑，不添加待缴费的挂号项目
        /// </remark>
        public string flag { get; set; } = "0";
    }

    /// <summary>
    /// 3004 data
    /// </summary>
    public class Hosp3004ResponseData
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        /// <value></value>
        public string hisRegisterId { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string registerId { get; set; } = string.Empty;

        /// <summary>
        /// HIS 交易发票号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        /// <value></value>
        public string vancy { get; set; } = string.Empty;

        /// <summary>
        /// 就诊序号
        /// </summary>
        public string seeNo { get; set; } = string.Empty;

        /// <summary>
        /// 科室地址
        /// </summary>
        /// <value></value>
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        /// <value></value>
        public string deptname { get; set; } = string.Empty;
    }

    /// <summary>
    /// 3004 返参
    /// </summary>
    public class Hosp3004Response : HospResponseModelBase<Hosp3004ResponseData> { }
    #endregion

    #region 3005
    /// <summary>
    /// 3005 挂号取消 入参
    /// </summary>
    [HospTransferCode("3005")]
    public class Hosp3005Request : HospRequestModelBase
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string registerId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string flag { get; set; } = "0";
    }

    /// <summary>
    /// 3005 data
    /// </summary>
    public class Hosp3005ResponseData { }

    /// <summary>
    /// 3005 挂号取消 返参
    /// </summary>
    public class Hosp3005Response : HospResponseModelBase<Hosp3005ResponseData> { }
    #endregion

    #region 4002
    /// <summary>
    /// 4002 待缴费列表查询 入参
    /// </summary>
    [HospTransferCode("4002")]
    public class Hosp4002Request : HospRequestModelBase
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// patientCard
        /// </summary>
        public string patientCard { get; set; } = string.Empty;
    }

    /// <summary>
    /// 4002 data
    /// </summary>
    public class Hosp4002ResponseData
    {
        /// <summary>
        /// 唯一号
        /// </summary>
        public string Recipe_Key { get; set; } = string.Empty;

        /// <summary>
        /// 处方号
        /// </summary>
        public string Recipe_No { get; set; } = string.Empty;

        /// <summary>
        /// 处方内序号
        /// </summary>
        public string SeqNo { get; set; } = string.Empty;

        /// <summary>
        /// 交易类型
        /// </summary>
        public string Trans_Type { get; set; } = string.Empty;

        /// <summary>
        /// 最小费用代码
        /// </summary>
        public string Fee_Code { get; set; } = string.Empty;

        /// <summary>
        /// 是否是药品
        /// </summary>
        public string Drug_Flag { get; set; } = string.Empty;

        /// <summary>
        /// 项目编码
        /// </summary>
        public string Item_Code { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item_Name { get; set; } = string.Empty;

        /// <summary>
        /// 数量
        /// </summary>
        public string Qty { get; set; } = string.Empty;

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; } = string.Empty;

        /// <summary>
        /// 用量
        /// </summary>
        public string Dose { get; set; } = string.Empty;

        /// <summary>
        /// 包装数量
        /// </summary>
        public string Pack_Qty { get; set; } = string.Empty;

        /// <summary>
        /// 天数
        /// </summary>
        public string Days { get; set; } = string.Empty;

        /// <summary>
        /// 复方标识
        /// </summary>
        public string Ff { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string Center_Code { get; set; } = string.Empty;

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT { get; set; } = string.Empty;

        /// <summary>
        /// 单价
        /// </summary>
        public string Unit_Price { get; set; } = string.Empty;

        /// <summary>
        /// 总额
        /// </summary>
        public string Tot_Cost { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生
        /// </summary>
        public string Doc_Name { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生编码
        /// </summary>
        public string Doc_Code { get; set; } = string.Empty;

        /// <summary>
        /// 单次用量
        /// </summary>
        public string OnceDose { get; set; } = string.Empty;

        public string Frequency { get; set; } = string.Empty;

        /// <summary>
        /// 开方医生所在科室
        /// </summary>
        public string DocDept_Name { get; set; } = string.Empty;

        /// <summary>
        /// 执行科室编码
        /// </summary>
        public string Exec_DeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 执行科室
        /// </summary>
        public string Exec_DeptName { get; set; } = string.Empty;

        /// <summary>
        /// 开立时间
        /// </summary>
        public string Mo_Date { get; set; } = string.Empty;

        /// <summary>
        /// 是否收费
        /// </summary>
        public string Pay_Flag { get; set; } = string.Empty;

        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string Moder { get; set; } = string.Empty;

        /// <summary>
        /// 挂号流水号
        /// </summary>
        public string ClinicCode { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string SysClass { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string Lab_Type { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string IsEmergency { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string hypo_test { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string combo { get; set; } = string.Empty;

        /// <summary>
        /// 包装数量
        /// </summary>
        public string PackQty { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string subcomb_no { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string usage_code { get; set; } = string.Empty;

        /// <summary>
        /// unkonwn
        /// </summary>
        public string pact_name { get; set; } = string.Empty;

        /// <summary>
        /// 物理卡号
        /// </summary>
        public string markno { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string price_unit { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string item_class { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string patientid { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string sex_code { get; set; } = string.Empty;

        /// <summary>
        /// 分方
        /// </summary>
        public string recipeSeq { get; set; } = string.Empty;

        /// <summary>
        /// 特慢病标识
        /// </summary>
        /// <value>0 普通/不能报销|1 可报销|2 慢病</value>
        public string icdType { get; set; } = string.Empty;

        /// <summary>
        /// 诊断编码
        /// </summary>
        public string icdCode { get; set; } = string.Empty;

        /// <summary>
        /// 0 普通/不可报销| 1 可报销
        /// </summary>
        public string HasSaved { get; set; } = string.Empty;

        /// <summary>
        /// 病种审批单号
        /// </summary>
        public string proCode { get; set; } = string.Empty;

        /// <summary>
        /// 诊断名称
        /// </summary>
        public string icdName { get; set; } = string.Empty;

        /// <summary>
        /// 值 PCC 是草药
        /// </summary>
        public string classCode { get; set; } = string.Empty;

        /// <summary>
        /// unknown
        /// </summary>
        public string MinUnit { get; set; } = string.Empty;
    }

    /// <summary>
    /// 4002 待缴费列表 返参
    /// </summary>
    public class Hosp4002Response : HospResponseModelBase<Hosp4002ResponseData[]> { }
    #endregion

    #region 4004
    /// <summary>
    /// 4004 门诊结算 入参
    /// </summary>
    [HospTransferCode("4004")]
    public class Hosp4004Request : HospRequestModelBase
    {
        /// <summary>
        /// 唯一号 使用 | 分隔
        /// </summary>
        public string recipe_Key { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// 操作编码 由 HIS 提供
        /// </summary>
        public string operCode { get; set; } = Startup.OperCode;

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <value>ZB 支付宝|WX 微信|CA 现金|CD 银行卡</value>
        public string feeSource { get; set; } = string.Empty;

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
        /// 第三方交易流水号
        /// </summary>
        public string tradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 自助机编号
        /// </summary>
        public string termId { get; set; } = string.Empty;

        /// <summary>
        /// 医保结算参数 使用 # 分隔
        /// </summary>
        public string siInfo { get; set; } = string.Empty;

        /// <summary>
        /// 医保卡信息
        /// </summary>
        public string siCardInfo { get; set; } = string.Empty;

        /// <summary>
        /// 医保卡余额
        /// </summary>
        public string siBalanceInfo { get; set; } = string.Empty;

        /// <summary>
        /// 分方
        /// </summary>
        public string recipeSeq { get; set; } = string.Empty;

        /// <summary>
        /// 最后组成的字符串(拆分) 
        /// </summary>
        public string Recipe_CF { get; set; } = string.Empty;

        /// <summary>
        /// 合同单位编码
        /// </summary>
        public string pactCode { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public string idCard { get; set; } = string.Empty;
    }

    /// <summary>
    /// 4004 data
    /// </summary>
    public class Hosp4004ResponseData
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
        public string deptname { get; set; } = string.Empty;

        /// <summary>
        /// 费用详细列表(应该是个类,暂时不用)
        /// </summary>
        public string FeeItemList { get; set; } = string.Empty;
    }

    /// <summary>
    /// 4004 门诊结算 返参
    /// </summary>
    public class Hosp4004Response : HospResponseModelBase<Hosp4004ResponseData> { }
    #endregion

    /// <summary>
    /// 检查报告入参
    /// </summary>
    public class HospReportQueryRequest : HospRequestModelBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string queryId { get; set; } = string.Empty;

        /// <summary>
        /// 1-检验 2-检查
        /// </summary>
        public string checkType { get; set; } = string.Empty;
    }

    public class HospReportQueryResponseData
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

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
        public string reportMessage { get; set; } = string.Empty;

        /// <summary>
        /// 检查结论
        /// </summary>
        public string repostResult { get; set; } = string.Empty;
    }

    /// <summary>
    /// 检查报告返参
    /// </summary>
    public class HospReportQueryResponse : HospResponseModelBase<HospReportQueryResponseData> { }

    /// <summary>
    /// 检验报告详情入参
    /// </summary>
    public class HospReportDetailRequest : HospRequestModelBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string queryId { get; set; } = string.Empty;

        /// <summary>
        /// 1-检验 2-检查
        /// </summary>
        public string checkType { get; set; } = string.Empty;
    }

    public class HospReportDetailResponseData
    {
        /// <summary>
        /// 报告名称
        /// </summary>
        public string itemName { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

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
        /// 样本
        /// </summary>
        public string sample { get; set; } = string.Empty;

        /// <summary>
        /// 实际值
        /// </summary>
        public string realResult { get; set; } = string.Empty;

        /// <summary>
        /// 参考值
        /// </summary>
        public string referprint { get; set; } = string.Empty;

        /// <summary>
        /// 结论
        /// </summary>
        public string conclusion { get; set; } = string.Empty;
    }

    /// <summary>
    /// 检验报告详情返参
    /// </summary>
    public class HospReportDetailResponse : HospResponseModelBase<HospReportDetailResponseData[]> { }

    /// <summary>
    /// 5001 request
    /// </summary>
    public class Hosp5001Request : HospRequestModelBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 就诊人卡号
        /// </summary>
        public string patientCard { get; set; } = string.Empty;

        /// <summary>
        /// 开始时间
        /// </summary>
        public string beginDate { get; set; } = string.Empty;

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; } = string.Empty;
    }

    public class Hosp5001ResponseData
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string queryId { get; set; } = string.Empty;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemName { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

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
    /// 5001 response
    /// </summary>
    public class Hosp5001Response : HospResponseModelBase<Hosp5001ResponseData[]> { }

    /// <summary>
    /// 4003 request
    /// </summary>
    public class Hosp4003Request : HospRequestModelBase
    {
        /// <summary>
        /// String 	是	唯一号 多个 | 分隔
        /// </summary>
        public string recipe_Key { get; set; } = string.Empty;

        /// <summary>
        /// String	是	就诊人姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// String	是	门诊流水号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;

        /// <summary>
        /// String	是	缴费操作员
        /// </summary>
        public string operCode { get; set; } = string.Empty;
    }

    public class Hosp4003ResponseData
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

    /// <summary>
    /// 4003 response
    /// </summary>
    public class Hosp4003Response : HospResponseModelBase<Hosp4003ResponseData> { }

    /// <summary>
    /// 挂号支付回调入参
    /// </summary>
    public class HospRegCallbackRequest : HospRequestModelBase
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
        public string thirdOrderNo { get; set; } = string.Empty;

        /// <summary>
        /// 支付方式 (支付必填)ZB 支付宝 WX 微信 CA 现金 CD 银行卡
        /// </summary>
        public string feeSource { get; set; } = string.Empty;

        /// <summary>
        /// 是否支付 0未支付 1账户支付 2已经支付
        /// </summary>
        public string isFee { get; set; } = string.Empty;

        /// <summary>
        /// 支付费用
        /// </summary>
        public string payFee { get; set; } = string.Empty;

        /// <summary>
        /// 医保结算参数多个#分隔
        /// </summary>
        public string siInfo { get; set; } = string.Empty;
    }

    public class HospRegCallbackResponseData
    {
        public int state { get; set; } = 0;
    }

    /// <summary>
    /// 挂号支付回调返参
    /// </summary>
    public class HospRegCallbackResponse : HospResponseModelBase<HospRegCallbackResponseData>
    {
        /// <summary>
        /// 就诊唯一号
        /// </summary>
        public string clinicNo { get; set; } = string.Empty;
    }
}
