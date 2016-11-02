using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFullFramework.Library.EFCore
{
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryItem> Inventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (optionsBuilder.IsConfigured == false)
                {
                    // Embedded Connection:
                    //optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=EFCoreDemo;Integrated Security=True;");

                    // Connection String:
                    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreDemo"].ConnectionString);
                }

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<InventoryItem>()
                .Property(i => i.Name)
                .IsRequired();
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options) { }

        public InventoryContext()
        { }
    }
}
