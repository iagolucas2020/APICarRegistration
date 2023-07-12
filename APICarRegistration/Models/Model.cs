using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public ICollection<Car>? Cars { get; set; }

        public int BrandId { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }
    }
}
