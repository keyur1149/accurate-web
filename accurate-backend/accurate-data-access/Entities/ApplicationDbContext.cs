using Microsoft.EntityFrameworkCore;

namespace accurate_data_access.Entities;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartItemTbl> CartItemTbls { get; set; }

    public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }

    public virtual DbSet<OrderItemTbl> OrderItemTbls { get; set; }

    public virtual DbSet<OrderTbl> OrderTbls { get; set; }

    public virtual DbSet<ProductAttributeTbl> ProductAttributeTbls { get; set; }

    public virtual DbSet<ProductAttributeValuesTbl> ProductAttributeValuesTbls { get; set; }

    public virtual DbSet<ProductCategoryTbl> ProductCategoryTbls { get; set; }

    public virtual DbSet<ProductTbl> ProductTbls { get; set; }

    public virtual DbSet<ProductVariationsTbl> ProductVariationsTbls { get; set; }

    public virtual DbSet<WishlistTbl> WishlistTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("name=accurate");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItemTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_item_tbl_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItemTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<CategoryTbl>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_tbl_pkey");
        });

        modelBuilder.Entity<OrderItemTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_item_tbl_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Order_item_tbl_Id_seq\"'::regclass)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order");

            entity.HasOne(d => d.ProductVariation).WithMany(p => p.OrderItemTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_variation");
        });

        modelBuilder.Entity<OrderTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_tbl_pkey");
        });

        modelBuilder.Entity<ProductAttributeTbl>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("productAttribute_tbl_pkey");

            entity.Property(e => e.AttributeId).HasDefaultValueSql("nextval('\"productAttribute_tbl_AttributeId_seq\"'::regclass)");
        });

        modelBuilder.Entity<ProductAttributeValuesTbl>(entity =>
        {
            entity.HasKey(e => e.ValueId).HasName("product_attribute_values_tbl_pkey");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributeValuesTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_attribute");
        });

        modelBuilder.Entity<ProductCategoryTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_category_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"product_category_Id_seq\"'::regclass)");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategoryTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_category");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategoryTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<ProductTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_tbl_pkey");
        });

        modelBuilder.Entity<ProductVariationsTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_variations_tbl_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariationsTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");

            entity.HasOne(d => d.Value).WithMany(p => p.ProductVariationsTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_value");
        });

        modelBuilder.Entity<WishlistTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wishlist_tbl_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.WishlistTbls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
