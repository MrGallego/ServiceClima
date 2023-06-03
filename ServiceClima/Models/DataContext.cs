using Microsoft.EntityFrameworkCore;

namespace ServiceClima.Models
{
	public class DataContext: DbContext
	{
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Clima> Climas { get; set; }
    }
}
