using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICarRegistration.Models
{
    [Table("Brands")]
    public class Brand
    {
        public Brand()
        {
            Models = new Collection<Model>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Name { get; set; }

        public ICollection<Model>? Models{ get; set; }
    }
}
