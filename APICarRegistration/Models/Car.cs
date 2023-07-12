namespace APICarRegistration.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }

        public int CategoryId { get; set; }
        public Category? Category{ get; set; }

        public int ModelId { get; set; }
        public Model? Model { get; set; }
    }
}
