namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public class HospProxySettings
    {
        public HospProxyModes Mode { get; set; }

        public string Url { get; set; }

        public string OperCode { get; set; }
    }

    public enum HospProxyModes
    {
        MockService = 0x00,
        WebService = 0x01,
        Socket = 0x02
    }
}
