using FluentValidation.TestHelper;
using ShopCredit.Application.CQRS.Queries.CustomerAccountQueries;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;

namespace ShopCredit.Tests.Validators
{
    [TestFixture]
    public class GetCustomerQueryValidatorTests
    {
        private GetCustomerQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GetCustomerQueryValidator();
        }

        [Test]
        public void Should_Have_Error_When_Name_Is_Too_Short()
        {
            var query = new GetCustomerQuery { Name = "A" };
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("İsim en az 2 karakter olmalıdır.");
        }

        [Test]
        public void Should_Have_Error_When_Surname_Is_Too_Long()
        {
            var query = new GetCustomerQuery { Surname = new string('A', 101) };
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Surname)
                  .WithErrorMessage("Soy isim en fazla 100 karakter olabilir.");
        }

        [Test]
        public void Should_Have_Error_When_PhoneNumber_Is_Invalid()
        {
            var query = new GetCustomerQuery { PhoneNumber = "12345" };
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                  .WithErrorMessage("Telefon numarası 10 haneli olmalıdır.");

            query = new GetCustomerQuery { PhoneNumber = "12345aa" };
            result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                  .WithErrorMessage("Telefon numarası sadece rakamlardan oluşmalıdır.");
        }

        [Test]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var query = new GetCustomerQuery { Email = "invalid-email" };
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Geçersiz Email formatı.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Query_Is_Valid()
        {
            var query = new GetCustomerQuery
            {
                Name = "ValidName",
                Surname = "ValidSurname",
                PhoneNumber = "1234567890",
                Email = "test@example.com"
            };

            var result = _validator.TestValidate(query);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
            result.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}
