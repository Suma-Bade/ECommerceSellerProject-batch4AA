using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SellerService.Entities
{
    public partial class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext()
        {
        }

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-S3RV3MH\\SQLEXPRESS;Initial Catalog=ECommerceDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Category__D837D05F466867FA");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdetails)
                    .HasColumnName("cdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoryname)
                    .HasColumnName("categoryname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stockno).HasColumnName("stockno");

                entity.Property(e => e.Subcategoryname)
                    .HasColumnName("subcategoryname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Seller__DDDFDD36CB539AA9");

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aboutcmpy)
                    .HasColumnName("aboutcmpy")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("gst");

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasColumnName("mobileno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.Subid)
                    .HasName("PK__SubCateg__B0F1D5B35EDAEEF1");

                entity.Property(e => e.Subid)
                    .HasColumnName("subid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("gst");

                entity.Property(e => e.Sdetails)
                    .HasColumnName("sdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subname)
                    .IsRequired()
                    .HasColumnName("subname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
