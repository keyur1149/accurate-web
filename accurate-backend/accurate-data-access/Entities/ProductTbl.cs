using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("product_tbl")]
public partial class ProductTbl
{
    [Key]
    public long ProductId { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [StringLength(1000)]
    public string ProductImage { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartItemTbl> CartItemTbls { get; set; } = new List<CartItemTbl>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductCategoryTbl> ProductCategoryTbls { get; set; } = new List<ProductCategoryTbl>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductVariationsTbl> ProductVariationsTbls { get; set; } = new List<ProductVariationsTbl>();

    [InverseProperty("Product")]
    public virtual ICollection<WishlistTbl> WishlistTbls { get; set; } = new List<WishlistTbl>();
}
