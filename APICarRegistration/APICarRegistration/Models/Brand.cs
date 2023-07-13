using APICarRegistration.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICarRegistration.Models
{
    [Table("Brands")]
    public sealed class Brand
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

        [JsonIgnore]
        public ICollection<Model>? Models{ get; set; }

        public Brand(string? name)
        {
            ValidateDomain(name);
        }

        public Brand(int id, string? name)
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
