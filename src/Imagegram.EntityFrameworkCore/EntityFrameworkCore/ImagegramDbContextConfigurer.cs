using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Imagegram.EntityFrameworkCore
{
    public static class ImagegramDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ImagegramDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ImagegramDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
