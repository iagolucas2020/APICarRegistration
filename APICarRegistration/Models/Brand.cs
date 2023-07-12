using System.Collections.ObjectModel;

namespace APICarRegistration.Models
{
    public class Brand
    {
        public Brand()
        {
            Models = new Collection<Model>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Model>? Models{ get; set; }
    }
}
