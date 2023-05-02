using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;
public class CustomerEntity
{
    [Key]
    public int CustomerID { get; set; }
}
