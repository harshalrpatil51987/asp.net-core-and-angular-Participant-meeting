using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eduvanz.Authorization;

namespace eduvanz
{
    [DependsOn(
        typeof(eduvanzCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class eduvanzApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<eduvanzAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(eduvanzApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
