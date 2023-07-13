using APICarRegistration.Models;
using FluentAssertions;

namespace APICarRegistration.Tests
{
    public class ModelUnitTest
    {
        [Fact(DisplayName = "Create Model With Valid State")]
        public void CreateModel_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Model(1, "Corrola");
            action.Should()
                .NotThrow<APICarRegistration.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Model With invalid State")]
        public void CreateModel_NegativeIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Model(-1, "Corrola");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Model With Name too long")]
        public void CreateModel_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Model(1, "Corrolaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long");
        }

        [Fact(DisplayName = "Create Model With Invalid Name")]
        public void CreateModel_WithNullNameValue_DomainExceptionInvalidaName()
        {
            Action action = () => new Model(1, "");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

    }
}