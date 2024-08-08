using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("order_tbl")]
public partial class OrderTbl
{
    [Key]
    public long Id { get; set; }

    public DateTime OrderTime { get; set; }

    public long TotalAmount { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();
}
