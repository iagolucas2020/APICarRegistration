using APICarRegistration.Models;
using FluentAssertions;

namespace APICarRegistration.Tests
{
    public class CarUnitTest
    {
        [Fact(DisplayName = "Create Car With Valid State")]
        public void CreateCar_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Car(1, "Carro Novo", 125990.99m, "2023", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .NotThrow<APICarRegistration.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Car With invalid State")]
        public void CreateCar_NegativeIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Car(-1, "Carro Novo", 125990.99m, "2023", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Car With Description too long")]
        public void CreateCar_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Car(1, "Carro Novoddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"
                , 125990.99m, "2023", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too long");
        }

        [Fact(DisplayName = "Create Car With Invalid Description")]
        public void CreateCar_WithNullNameValue_DomainExceptionInvalidaDescription()
        {
            Action action = () => new Car(1, "", 125990.99m, "2023", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description.Description is required");
        }

        [Fact(DisplayName = "Create Car With Value less than zero")]
        public void CreateCar_WithNullPriceValueLessThanZero_DomainExceptionInvalidaPrice()
        {
            Action action = () => new Car(1, "Carro Zero", -1m, "2023", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Car With Invalid Model Year")]
        public void CreateCar_WithNullModelYearValue_DomainExceptionInvalidaModelYear()
        {
            Action action = () => new Car(1, "Carro Zero", 125990.99m, "", "2022", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Modey Year is required");
        }

        [Fact(DisplayName = "Create Car With Invalid Manufacture Year")]
        public void CreateCar_WithNullManufactureYearValue_DomainExceptionInvalidaManufactureYear()
        {
            Action action = () => new Car(1, "Carro Zero", 125990.99m, "2023", "", DateTime.Now, "corola2022.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Manufacture Year is required");
        }

        [Fact(DisplayName = "Create Car With Image too long")]
        public void CreateCar_LongImageValue_DomainExceptionLongImage()
        {
            Action action = () => new Car(1, "Carro Novo"
                , 125990.99m, "2023", "2022", DateTime.Now, "Carro NovoddddddddddddddddddddddddddddddddddddNovodddddddddddddddddddddddddddddddddddddddddddddddddddddNovodddddddddddddddddddddddddddddddddddddddddddddddddddddNovodddddddddddddddddddddddddddddddddddddddddddddddddddddNovodddddddddddddddddddddddddddddddddddddddddddddddddddddNovodddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd.jpg");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long");
        }

    }
}