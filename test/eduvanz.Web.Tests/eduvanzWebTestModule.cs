using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eduvanz.EntityFrameworkCore;
using eduvanz.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace eduvanz.Web.Tests
{
    [DependsOn(
        typeof(eduvanzWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class eduvanzWebTestModule : AbpModule
    {
        public eduvanzWebTestModule(eduvanzEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eduvanzWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(eduvanzWebMvcModule).Assembly);
        }
    }
}