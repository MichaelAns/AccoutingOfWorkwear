using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AoW.EntityFramework.Date
{
    public class AowDbContextFactory : IDesignTimeDbContextFactory<AowDbContext>
    {
        public AowDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<AowDbContext>();
            options.UseSqlite("Filename = Aow.db");
            return new AowDbContext(options.Options);
        }
    }
}
