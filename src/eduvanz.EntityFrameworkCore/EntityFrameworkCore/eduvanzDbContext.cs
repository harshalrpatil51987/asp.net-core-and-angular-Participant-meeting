using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eduvanz.Authorization.Roles;
using eduvanz.Authorization.Users;
using eduvanz.MultiTenancy;
using Abp.Authorization.Users;
using eduvanz.Meetup.MeetupEvents;

namespace eduvanz.EntityFrameworkCore
{
    public class eduvanzDbContext : AbpZeroDbContext<Tenant, Role, User, eduvanzDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<MeetupEvent> MeetupEvents { get; set; }

        public virtual DbSet<StateMaster> StateMasters { get; set; }
        
        public eduvanzDbContext(DbContextOptions<eduvanzDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
