using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace eduvanz.EntityFrameworkCore
{
    public static class eduvanzDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<eduvanzDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<eduvanzDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
