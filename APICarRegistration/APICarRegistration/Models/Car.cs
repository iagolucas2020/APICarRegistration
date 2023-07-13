using APICarRegistration.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICarRegistration.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(4)]
        public string? ModelYear { get; set; }

        [Required]
        [StringLength(4)]
        public string? ManufactureYear { get; set; }

        public DateTime RegisterDate { get; set; }

        [StringLength(300)]
        public string? ImageUrl{ get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category{ get; set; }

        public int ModelId { get; set; }

        [JsonIgnore]
        public Model? Model { get; set; }

        public Car(int id, string? description, decimal price, string? modelYear, string? manufactureYear, DateTime registerDate, string? imageUrl)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(description, price, modelYear, manufactureYear, registerDate, imageUrl);
        }

        private void ValidateDomain(string description, decimal price, string? modelYear, string? manufactureYear, DateTime registerDate, string imageUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description is required");

            DomainExceptionValidation.When(description.Length > 100, "Invalid description, too long");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(string.IsNullOrEmpty(modelYear), "Invalid Modey Year is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(manufactureYear), "Invalid Manufacture Year is required");

            DomainExceptionValidation.When(imageUrl.Length > 250, "Invalid image name, too long");

            Description = description;
            Price = price;
            ModelYear = modelYear;
            ManufactureYear = manufactureYear;
            RegisterDate = registerDate;
            ImageUrl = imageUrl;
        }
    }
}
