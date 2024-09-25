using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Users> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // setup database connection
        //    optionsBuilder.UseSqlServer("Data Source=DOTNET-TRAINEE2;Integrated Security=True;Database=webDataBase;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder

            //explicitly set a property to be a primary key
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Addresses)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonID)
                .HasPrincipalKey(p => p.ID);

            modelBuilder.Entity<Person>()
                .Property(y => y.FirstName)
                .IsRequired()
                .HasColumnName("FName")
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Person>()
                .Property(z => z.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .HasColumnName("LName");


            modelBuilder.Entity<Address>( entity => 
            {
                entity.HasKey(k => k.ID);
                entity.Property(a => a.Country).HasColumnName("Country");
                entity.Property(c => c.City).HasColumnName("City");
                entity.Property(s => s.Street).HasColumnName("Street");
                entity.Property(p => p.Phone).HasColumnName("Phone");
                //entity.HasOne(Person).WithMany(a => a.Addresses).HasForeignKey(f => f.PersonID).OnDelete(DeleteBehavior.Cascade);
            });
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

    }
}
