using System.ComponentModel.Composition;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    [Export(typeof(Agebull.ZeroNet.ZeroApi.IAutoRegister))]
    [ExportMetadata("Symbol", '%')]
    public sealed class AutoRegister : Agebull.ZeroNet.ZeroApi.IAutoRegister
    {
        public void Initialize()
        {
            // Agebull.Common.Ioc.IocHelper.AddSingleton<Interface, Implement>();
        }

        public void AutoRegist()
        {
            Agebull.ZeroNet.Core.ZeroApplication.Discove(GetType().Assembly);
        }
    }
}
