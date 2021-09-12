using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Imagegram.Authorization.Roles;
using Imagegram.Authorization.Users;
using Imagegram.MultiTenancy;
using Imagegram.Imagegram;

namespace Imagegram.EntityFrameworkCore
{
    public class ImagegramDbContext : AbpZeroDbContext<Tenant, Role, User, ImagegramDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }

        public ImagegramDbContext(DbContextOptions<ImagegramDbContext> options)
            : base(options)
        {
        }
    }
}
