using APICarRegistration.Models;
using FluentAssertions;

namespace APICarRegistration.Tests
{
    public class BrandUnitTest
    {
        [Fact(DisplayName = "Create Brand With Valid State")]
        public void CreateBrand_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Brand(1, "Kia");
            action.Should()
                .NotThrow<APICarRegistration.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Brand With invalid State")]
        public void CreateBrand_NegativeIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Brand(-1, "Kia");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Brand With Name too long")]
        public void CreateBrand_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Brand(1, "Kiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long");
        }

        [Fact(DisplayName = "Create Brand With Invalid Name")]
        public void CreateBrand_WithNullNameValue_DomainExceptionInvalidaName()
        {
            Action action = () => new Brand(1, "");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }
    }
}