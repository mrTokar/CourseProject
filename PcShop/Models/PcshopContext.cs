using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PcShop.Models;

public partial class PcshopContext : DbContext
{
    public PcshopContext()
    {
    }

    public PcshopContext(DbContextOptions<PcshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TemplateType> TemplateTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum<OrderStatus>(name: "order_status")
            .HasPostgresEnum<PaymentType>(name: "payment_type")
            .HasPostgresEnum<ProductStatus>(name: "product_status")
            .HasPostgresEnum<UserRole>(name: "user_role");

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.UserLogin, e.IdModel }).HasName("pk_cart");

            entity.ToTable("cart", "users_data");

            entity.Property(e => e.UserLogin)
                .HasMaxLength(256)
                .HasColumnName("user_login");
            entity.Property(e => e.IdModel).HasColumnName("id_model");
            entity.Property(e => e.Count)
                .HasPrecision(2)
                .HasColumnName("count");

            entity.HasOne(d => d.IdModelNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdModel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cart_model");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cart_user");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("locations_pkey");

            entity.ToTable("locations", "logistics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .HasColumnName("city");
            entity.Property(e => e.House)
                .HasMaxLength(5)
                .HasColumnName("house");
            entity.Property(e => e.Schedules)
                .HasColumnType("jsonb")
                .HasColumnName("schedules");
            entity.Property(e => e.Street)
                .HasMaxLength(40)
                .HasColumnName("street");
            entity.Property(e => e.Type)
                .HasMaxLength(7)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("models_pkey");

            entity.ToTable("models", "catalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count)
                .HasPrecision(5)
                .HasColumnName("count");
            entity.Property(e => e.Fabric)
                .HasMaxLength(10)
                .HasColumnName("fabric");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");
            entity.Property(e => e.Specifications)
                .HasColumnType("jsonb")
                .HasColumnName("specifications");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_models_type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_dt");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(OrderStatus.Collecting);
            entity.Property(e => e.Paid)
                .HasDefaultValue(false)
                .HasColumnName("paid");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.PaymentInfo).HasColumnName("payment_info");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(12, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(256)
                .HasColumnName("user_login");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_orders_location");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserLogin)
                .HasConstraintName("fk_orders_user");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products", "catalog");

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .HasColumnName("id");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(ProductStatus.Free);
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("fk_products_location");

            entity.HasOne(d => d.ModelNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Model)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_model");

            entity.HasMany(d => d.Orders).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_productorder_order"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_productorder_product"),
                    j =>
                    {
                        j.HasKey("ProductId", "OrderId").HasName("pk_productorder");
                        j.ToTable("product_order", "sales");
                        j.IndexerProperty<string>("ProductId")
                            .HasMaxLength(32)
                            .HasColumnName("product_id");
                        j.IndexerProperty<int>("OrderId").HasColumnName("order_id");
                    });
        });

        modelBuilder.Entity<TemplateType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("template_type_pkey");

            entity.ToTable("template_type", "catalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Specifications)
                .HasColumnType("jsonb")
                .HasColumnName("specifications");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("users_pkey");

            entity.ToTable("users", "users_data");

            entity.Property(e => e.Login)
                .HasMaxLength(256)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(UserRole.Client);

            entity.HasMany(d => d.IdLocations).WithMany(p => p.UserLogins)
                .UsingEntity<Dictionary<string, object>>(
                    "SavedLocation",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("IdLocation")
                        .HasConstraintName("fk_saved_locations_location"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserLogin")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_saved_locations_user"),
                    j =>
                    {
                        j.HasKey("UserLogin", "IdLocation").HasName("pk_saved_locations");
                        j.ToTable("saved_locations", "users_data");
                        j.IndexerProperty<string>("UserLogin")
                            .HasMaxLength(256)
                            .HasColumnName("user_login");
                        j.IndexerProperty<int>("IdLocation").HasColumnName("id_location");
                    });

            entity.HasMany(d => d.IdModels).WithMany(p => p.UserLogins)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorite",
                    r => r.HasOne<Model>().WithMany()
                        .HasForeignKey("IdModel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_favorites_model"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserLogin")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_favorites_user"),
                    j =>
                    {
                        j.HasKey("UserLogin", "IdModel").HasName("pk_favorites");
                        j.ToTable("favorites", "users_data");
                        j.IndexerProperty<string>("UserLogin")
                            .HasMaxLength(256)
                            .HasColumnName("user_login");
                        j.IndexerProperty<int>("IdModel").HasColumnName("id_model");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
