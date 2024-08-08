using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("order_item_tbl")]
public partial class OrderItemTbl
{
    [Key]
    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ProductVariationId { get; set; }

    public long Quantity { get; set; }

    public double UnitPrice { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItemTbls")]
    public virtual OrderTbl Order { get; set; } = null!;

    [ForeignKey("ProductVariationId")]
    [InverseProperty("OrderItemTbls")]
    public virtual ProductVariationsTbl ProductVariation { get; set; } = null!;
}
