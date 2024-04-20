using Crud.EF.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Crud.EF
{
    public class CourseContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public CourseContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Post"));
        }

        public DbSet<Course> courseset { get; set;}
    }
}
