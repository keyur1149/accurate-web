using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accurate_data_access.Entities;

[Table("product_attribute_tbl")]
public partial class ProductAttributeTbl
{
    [Key]
    public long AttributeId { get; set; }

    [StringLength(100)]
    public string AttributeName { get; set; } = null!;

    [InverseProperty("Attribute")]
    public virtual ICollection<ProductAttributeValuesTbl> ProductAttributeValuesTbls { get; set; } = new List<ProductAttributeValuesTbl>();
}
