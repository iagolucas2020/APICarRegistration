using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICarRegistration.Models
{
    [Table("Models")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Name { get; set; }

        public ICollection<Car>? Cars { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
