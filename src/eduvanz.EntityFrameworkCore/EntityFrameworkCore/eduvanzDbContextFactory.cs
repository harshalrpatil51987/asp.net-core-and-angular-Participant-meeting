using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using eduvanz.Configuration;
using eduvanz.Web;

namespace eduvanz.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class eduvanzDbContextFactory : IDesignTimeDbContextFactory<eduvanzDbContext>
    {
        public eduvanzDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eduvanzDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            eduvanzDbContextConfigurer.Configure(builder, configuration.GetConnectionString(eduvanzConsts.ConnectionStringName));

            return new eduvanzDbContext(builder.Options);
        }
    }
}
