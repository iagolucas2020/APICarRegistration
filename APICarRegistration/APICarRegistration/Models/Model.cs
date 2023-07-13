using APICarRegistration.Validation;
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

        public ICollection<Car>? Cars { get; set; }

        public int BrandId { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }

        public Model(string? name, ICollection<Car>? cars, int brandId)
        {
            ValidateDomain(name);
        }

        public Model(int id, string? name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length > 20, "Invalid name, too long");

            Name = name;
        }
    }
}
