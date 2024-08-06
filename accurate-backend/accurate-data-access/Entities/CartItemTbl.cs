using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace accurate_data_access.Entities;

[Table("cart_item_tbl")]
public partial class CartItemTbl
{
    [Key]
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long? UserId { get; set; }

    public long? SessionId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("CartItemTbls")]
    public virtual ProductTbl Product { get; set; } = null!;
}
