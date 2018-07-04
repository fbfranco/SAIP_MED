using Microsoft.EntityFrameworkCore;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.DATA.Config
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=BISMARCK-PC\SQLEXPRESS;Initial Catalog=SAIP_MED_DB;Integrated Security=True");
        }
        
        public DbSet<Documento> Documento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>().HasKey(x => x.IdDocumento);
        }
        
    }
}