using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace accurate_data_access.Entities;

[Table("product_attribute_values_tbl")]
public partial class ProductAttributeValuesTbl
{
    [Key]
    public long ValueId { get; set; }

    public long AttributeId { get; set; }

    [StringLength(50)]
    public string Value { get; set; } = null!;

    [ForeignKey("AttributeId")]
    [InverseProperty("ProductAttributeValuesTbls")]
    public virtual ProductAttributeTbl Attribute { get; set; } = null!;

    [InverseProperty("Value")]
    public virtual ICollection<ProductVariationsTbl> ProductVariationsTbls { get; set; } = new List<ProductVariationsTbl>();
}
