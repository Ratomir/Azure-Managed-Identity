using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;
public class ProductEntity
{
    [Key]
    public int ProductModelId { get; set; }

    [Required]
    public string Name { get; set; }
}
