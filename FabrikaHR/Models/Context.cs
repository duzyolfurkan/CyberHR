using FabrikaHR.Models.Concrate;
using Microsoft.EntityFrameworkCore;

namespace FabrikaHR.Models
{
    public class Context : DbContext
    {
        //Server bağlantısı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FURKANDUZYOL\\MSSQLSERVERFD;Database=CyberHR_DB;Trusted_Connection=True;");
        }

        //Tabloların DBContext'e tanıtılması
        public DbSet<Avans> Avanses { get; set; }
        public DbSet<Harcama> Harcamas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
