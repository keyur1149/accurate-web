using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace accurate_data_access.Entities;

[Table("product_variations_tbl")]
public partial class ProductVariationsTbl
{
    public long ValueId { get; set; }

    public long ProductId { get; set; }

    public long Price { get; set; }

    [Key]
    public long Id { get; set; }

    [InverseProperty("ProductVariation")]
    public virtual ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();

    [ForeignKey("ProductId")]
    [InverseProperty("ProductVariationsTbls")]
    public virtual ProductTbl Product { get; set; } = null!;

    [ForeignKey("ValueId")]
    [InverseProperty("ProductVariationsTbls")]
    public virtual ProductAttributeValuesTbl Value { get; set; } = null!;
}
