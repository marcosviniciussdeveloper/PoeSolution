using Microsoft.EntityFrameworkCore;
using Poe.Modulo.Logs.Entity;

namespace Poe.Infraestructure.Data;

public class PoeDbContext : DbContext
{

        public PoeDbContext(DbContextOptions options) : base(options){}
        
        
        public DbSet<LogEventEntity> LogEvents { get; set; }    
}