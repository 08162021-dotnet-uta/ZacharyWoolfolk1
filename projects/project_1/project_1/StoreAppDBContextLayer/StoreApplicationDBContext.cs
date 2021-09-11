using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreAppDBContextLayer.EFModels
{
    public partial class StoreApplicationDBContext : DbContext
    {
        public StoreApplicationDBContext()
        {
        }

        public StoreApplicationDBContext(DbContextOptions<StoreApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StoreApplicationDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Location__3B82F1016C521C34");

                entity.Property(e => e.Location1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Location");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ItemizedId)
                    .HasName("PK__Orders__AB3A49C5497B62AB");

                entity.Property(e => e.ItemizedId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__3D5E1FD2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__ProductI__3E52440B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreId__3F466844");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => e.ItemizedId)
                    .HasName("PK__StoreInv__AB3A49C5FB739DC9");

                entity.ToTable("StoreInventory");

                entity.Property(e => e.ItemizedId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoreInve__Produ__38996AB5");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoreInve__Store__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
