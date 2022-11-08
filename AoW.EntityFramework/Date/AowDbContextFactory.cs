using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AoW.EntityFramework.Date
{
    public class AowDbContextFactory : IDesignTimeDbContextFactory<AowDbContext>
    {
        public AowDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<AowDbContext>();
            options.UseSqlite("Filename = C:\\Users\\Borov\\source\\repos\\AccoutingOfWorkwear\\AoW.EntityFramework\\Aow.db");
            return new AowDbContext(options.Options);
        }
    }
}
