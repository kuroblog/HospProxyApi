using Agebull.Common.Ioc;
using Agebull.ZeroNet.Core;
using BinXiangHealth.EMT.Hosp.ProxyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public class Startup
    {
        public static string OperCode { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Agebull.Common.Configuration.ConfigurationManager.SetConfiguration(configuration);
            ZeroApplication.CheckOption();

            OperCode = configuration.GetSection(nameof(HospProxySettings)).GetSection(nameof(HospProxySettings.OperCode)).Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region standard api
            services.AddOptions();
            services.Configure<HospProxySettings>(Configuration.GetSection(nameof(HospProxySettings)));
            services.AddScoped<ITestService, TestService>();
            //IocHelper.AddScoped<IHospProxyService, HospWebProxyService>();
            //IocHelper.AddScoped<IProxyService, ProxyService>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region zmq api
            IocHelper.ServiceCollection.Configure<HospProxySettings>(Configuration.GetSection(nameof(HospProxySettings)));
            IocHelper.AddScoped<ITestService, TestService>();
            IocHelper.AddScoped<IHospProxyService, HospMockProxyService>();
            IocHelper.AddScoped<IHospProxyService, HospWebProxyService>();
            IocHelper.AddScoped<IProxyService, ProxyService>();

            ZeroApplication.Initialize();

            var iar = new AutoRegister();
            iar.Initialize();
            iar.AutoRegist();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

#if !DEBUG
            app.UseHttpsRedirection();
#endif
            app.UseMvc();

            Task.Factory.StartNew(ZeroApplication.Run);
        }
    }
}
