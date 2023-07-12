using System.Collections.ObjectModel;

namespace APICarRegistration.Models;

public class Category
{
    public Category()
    {
        Cars = new Collection<Car>();
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Car>? Cars { get; set; }
}
