using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("category_tbl")]
public partial class CategoryTbl
{
    [Key]
    public long CategoryId { get; set; }

    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [StringLength(1000)]
    public string CategoryImage { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ProductCategoryTbl> ProductCategoryTbls { get; set; } = new List<ProductCategoryTbl>();
}
