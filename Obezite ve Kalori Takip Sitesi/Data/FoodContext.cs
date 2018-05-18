using Obezite_ve_Kalori_Takip_Sitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace Obezite_ve_Kalori_Takip_Sitesi.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }

        public DbSet<Baklagil> Baklagiller { get; set; }
        public DbSet<DenizÜrünü> DenizÜrünleri { get; set; }
        public DbSet<Et> Etler { get; set; }
        public DbSet<Kuruyemiş> Kuruyemişler { get; set; }
        public DbSet<Meyve> Meyveler { get; set; }
        public DbSet<Sebze> Sebzeler { get; set; }
        public DbSet<SütYumurta> SütVeYumurtaÜrünleri { get; set; }
        public DbSet<Yağ> Yağlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baklagil>().ToTable("Baklagil");
            modelBuilder.Entity<DenizÜrünü>().ToTable("DenizÜrünleri");
            modelBuilder.Entity<Et>().ToTable("Et");
            modelBuilder.Entity<Kuruyemiş>().ToTable("Kuruyemiş");
            modelBuilder.Entity<Meyve>().ToTable("Meyve");
            modelBuilder.Entity<Sebze>().ToTable("Sebze");
            modelBuilder.Entity<SütYumurta>().ToTable("SütYumurta");
            modelBuilder.Entity<Yağ>().ToTable("Yağ");
        }

        public DbSet<Obezite_ve_Kalori_Takip_Sitesi.Models.MyViewModel> MyViewModel { get; set; }
    }
}
