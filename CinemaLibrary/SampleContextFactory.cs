using Microsoft.EntityFrameworkCore.Design;

namespace CinemaLibrary
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            return new ApplicationContext(ApplicationContext.GetDb());
        }
    }
}
