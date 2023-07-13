using APICarRegistration.Models;
using FluentAssertions;

namespace APICarRegistration.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Motoneta");
            action.Should()
                .NotThrow<APICarRegistration.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With invalid State")]
        public void CreateCategory_NegativeIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Category(-1, "Motoneta");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Name too long")]
        public void CreateCategory_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Category(1, "Motonetafffffffffffffffsdfdfffffffff");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long");
        }

        [Fact(DisplayName = "Create Category With Invalid Name")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidaName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<APICarRegistration.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }
    }
}