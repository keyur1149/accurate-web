using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("wishlist_tbl")]
public partial class WishlistTbl
{
    [Key]
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long UserId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("WishlistTbls")]
    public virtual ProductTbl Product { get; set; } = null!;
}
