namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public static class StringExtensions
    {
        public static string FormatHospResult(this string hisResult)
        {
            return hisResult.Replace("\"[", "[").Replace("]\"", "]").Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\"");
        }
    }
}
