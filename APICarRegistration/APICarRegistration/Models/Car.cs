﻿using System.ComponentModel.DataAnnotations;
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
    }
}