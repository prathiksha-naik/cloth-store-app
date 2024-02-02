using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Domain.Entities;

public partial class ClothStoreContext : DbContext
{
    public ClothStoreContext()
    {
    }

    public ClothStoreContext(DbContextOptions<ClothStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ClothCategory> ClothCategories { get; set; }

    public virtual DbSet<ClothItem> ClothItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<SizeVariant> SizeVariants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=ELW5196;Initial Catalog=ClothStore;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__DAD4F3BEAA3291AC");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7972DBF1C4C");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WishlistId).HasColumnName("WishlistID");

            entity.HasOne(d => d.ClothItem).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ClothItemId)
                .HasConstraintName("FK__Cart__ClothItemI__1AD3FDA4");

            entity.HasOne(d => d.Size).WithMany(p => p.Carts)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__Cart__SizeID__1BC821DD");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__UserID__19DFD96B");

            entity.HasOne(d => d.Wishlist).WithMany(p => p.Carts)
                .HasForeignKey(d => d.WishlistId)
                .HasConstraintName("FK__Cart__WishlistID__1CBC4616");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BDC11BC65");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClothCategory>(entity =>
        {
            entity.HasKey(e => e.ClothCategoryId).HasName("PK__ClothCat__E5E9BD1A0DB05FC5");

            entity.ToTable("ClothCategory");

            entity.Property(e => e.ClothCategoryId).HasColumnName("ClothCategoryID");
            entity.Property(e => e.ClothCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClothItem>(entity =>
        {
            entity.HasKey(e => e.ClothItemId).HasName("PK__ClothIte__ED72E69827B9F60C");

            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ClothCategoryId).HasColumnName("ClothCategoryID");
            entity.Property(e => e.ItemName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.ClothItems)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__ClothItem__Brand__08B54D69");

            entity.HasOne(d => d.Category).WithMany(p => p.ClothItems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ClothItem__Categ__07C12930");

            entity.HasOne(d => d.ClothCategory).WithMany(p => p.ClothItems)
                .HasForeignKey(d => d.ClothCategoryId)
                .HasConstraintName("FK__ClothItem__Cloth__09A971A2");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF37669F8B");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__0F624AF8");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1138DDE1F");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ClothItem).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ClothItemId)
                .HasConstraintName("FK__OrderItem__Cloth__1332DBDC");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__123EB7A3");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AED973654B");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ClothItem).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ClothItemId)
                .HasConstraintName("FK__Reviews__ClothIt__22751F6C");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__2180FB33");
        });

        modelBuilder.Entity<SizeVariant>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__SizeVari__83BD095AEDA97042");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.Size)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.ClothItem).WithMany(p => p.SizeVariants)
                .HasForeignKey(d => d.ClothItemId)
                .HasConstraintName("FK__SizeVaria__Cloth__0C85DE4D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1E6146B3");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PK__Wishlist__233189CB8C2C9B51");

            entity.ToTable("Wishlist");

            entity.Property(e => e.WishlistId).HasColumnName("WishlistID");
            entity.Property(e => e.ClothItemId).HasColumnName("ClothItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ClothItem).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ClothItemId)
                .HasConstraintName("FK__Wishlist__ClothI__17036CC0");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wishlist__UserID__160F4887");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
