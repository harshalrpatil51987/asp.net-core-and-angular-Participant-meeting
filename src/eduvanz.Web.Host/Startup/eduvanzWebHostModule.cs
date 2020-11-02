using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eduvanz.Configuration;

namespace eduvanz.Web.Host.Startup
{
    [DependsOn(
       typeof(eduvanzWebCoreModule))]
    public class eduvanzWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public eduvanzWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eduvanzWebHostModule).GetAssembly());
        }
    }
}
