using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace Library.Infrastructure.Data
{
    public class PaymentServicesContext : DbContext
    {
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        //public virtual DbSet<Company> Companies { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderCompany> ProviderCompanies { get; set; }
        public DbSet<OperationsAPI> OperationsAPIs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProviderServices> ProviderServices { get; set; }
        public DbSet<CustomerAccounts> CustomerAccounts { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<TransactionStatus> Transactions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<UserTypeRole> UserTypeRoles { get; set; }
        public DbSet<UserPermissions> PermissionUsers { get; set; }
        public DbSet<LogsPermission> LogsPermissions { get; set; }

        public PaymentServicesContext(DbContextOptions<PaymentServicesContext> options) : base(options)
        {

        }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Company>(entity =>
        //    {
        //        entity.Property(e => e.id)
        //            .ValueGeneratedOnAdd()
        //            .UseIdentityColumn();

        //        entity.HasKey(e => e.id).HasName("id");

        //        entity.Property(e => e.nameAr)
        //            .HasMaxLength(30)
        //            .IsRequired();
        //    });

        //    //OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        

        /*
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CD73B27013");

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }
         */

    }
}
