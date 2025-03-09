using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kund> Kunder { get; set; }
        public DbSet<Tjanst> Tjanster { get; set; }
        public DbSet<Projekt> Projekt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projekt>()
                .HasKey(p => p.Projektnummer);

            modelBuilder.Entity<Projekt>()
                .HasOne(p => p.Kund)
                .WithMany(k => k.Projekt)
                .HasForeignKey(p => p.Kundnummer);

            modelBuilder.Entity<Projekt>()
                .HasOne(p => p.Tjanst)
                .WithMany(t => t.Projekt)
                .HasForeignKey(p => p.TjanstId);

            modelBuilder.Entity<Kund>()
                .HasKey(k => k.Kundnummer);


            //ChatGPT - fyll databas med kund och tjänst då vi inte behöver göra det i frontend
            modelBuilder.Entity<Kund>().HasData(
               new Kund
               {
                   Kundnummer = 1,
                   Namn = "Kund Kundsson",
                   Telefonnummer = "0123456789"
               });

            modelBuilder.Entity<Tjanst>().HasData(
                new Tjanst
                {
                    TjanstId = 1,
                    Namn = "Tjänst",
                    PrisPerTimme = 1000
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjektSystemDB;Trusted_Connection=True;");
            }
        }
    }
}
