using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICarRegistration.Models;

[Table("Categories")]
public class Category
{
    public Category()
    {
        Cars = new Collection<Car>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string? Name { get; set; }

    public ICollection<Car>? Cars { get; set; }
}
