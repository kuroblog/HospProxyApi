namespace BinXiangHealth.EMT.Hosp.ProxyApi.Models
{
    /// <summary>
    /// dict query request
    /// </summary>
    /// <seealse cref="HOSP.JHWR.Hosp0000Request"/>
    public class DictQueryRequest : ProxyRequestModelBase, IProxyRequestModel
    {
        /// <summary>
        /// key
        /// </summary>
        /// <value>EMPLOYEE|DEPARTMENT|REGLEVEL|PACTUNITINFO|NOON|PAYKIND</value>
        public string key { get; set; } = string.Empty;

        /// <summary>
        /// code
        /// </summary>
        /// <value></value>
        public string code { get; set; } = string.Empty;
    }

    /// <summary>
    /// dict query response
    /// </summary>
    /// <seealso cref="HOSP.JHWR.Hosp0000ResponseData"/>
    public class DictQueryResponse : IProxyResponseModel
    {
        /// <summary>
        /// code
        /// </summary>
        /// <value></value>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// name
        /// </summary>
        /// <value></value>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// desc
        /// </summary>
        /// <value></value>
        public string desc { get; set; } = string.Empty;
    }
}