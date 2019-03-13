using Newtonsoft.Json;
//using System.Collections.Generic;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public static class GenericExtensions
    {
        public static string ToJson<TObj>(this TObj obj, bool isIndented = false)
        {
            return JsonConvert.SerializeObject(obj, isIndented ? Formatting.Indented : Formatting.None);
        }

        //public static string ToJson<TObj>(IEnumerable<TObj> obj, Formatting format = Formatting.Indented)
        //{
        //    return JsonConvert.SerializeObject(obj, format);
        //}
    }
}
