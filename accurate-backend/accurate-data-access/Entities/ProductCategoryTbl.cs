using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace accurate_data_access.Entities;

[Table("product_category_tbl")]
public partial class ProductCategoryTbl
{
    [Key]
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ProductCategoryTbls")]
    public virtual CategoryTbl Category { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("ProductCategoryTbls")]
    public virtual ProductTbl Product { get; set; } = null!;
}
