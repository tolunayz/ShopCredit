using FluentValidation.TestHelper;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;

namespace ShopCredit.UnitTest
{
    [TestFixture]
    public class CustomerValidatorUnitTest
    {
        private CreateCustomerCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CreateCustomerCommandValidator();
        }

        [Test]
        public void Customer_CorrectCustomerFormat_ValidCustomer()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Email = "örnek@gmail.com",
                PhoneNumber = "1234567890",
                Address = "Ýstanbul",
                Name = "Name",
                Surname = "SurName"
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void Customer_IncorrectEmailFormat_InvalidEmail()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Email = "örnekinvalid.com"
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email).WithErrorMessage("Geçersiz Email.");
        }

        [Test]
        public void Customer_IncorrectPhoneNumberFormat_InvalidPhoneNumber()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                PhoneNumber = "123"     
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
                  .WithErrorMessage("Telefon numarasý 10 haneli olmalýdýr.");
        }

        [Test]
        public void Customer_IncorrectAddressLength_InvalidLengthAddress()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Address = new string('a', 201)  
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Address)
                  .WithErrorMessage("Adres 200 karakterden uzun olamaz.");
        }

        [Test]
        public void Customer_IncorrectNameLength_InvalidMaxLengthName()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Name = new string('a', 101) 
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage("Ýsim en fazla 100 karakter olabilir.");
        }

        [Test]
        public void Customer_IncorrectNameLength_InvalidMinLengthName()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Name = "ab"     
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage("Ýsim en az 3 karakter olmalýdýr.");
        }

        [Test]
        public void Customer_IncorrectSurnameLength_InvalidMaxLengthSurname()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Surname = new string('a', 101)     
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Surname)
                  .WithErrorMessage("Soy isim en fazla 100 karakter olabilir.");
        }

        [Test]
        public void Customer_IncorrectSurnameLength_InvalidMinLengthSurname()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Surname = "ab"  
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Surname)
                  .WithErrorMessage("Soy isim en az 3 karakter olmalýdýr.");
        }

        [Test]
        public void Customer_PhoneNumberIsEmpty_ShouldHaveError()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                PhoneNumber = ""
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
                  .WithErrorMessage("Telefon numarasý boþ býrakýlamaz.");
        }

        [Test]
        public void Customer_AddressIsEmpty_ShouldHaveError()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Address = ""
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Address)
                  .WithErrorMessage("Adres alaný boþ býrakýlamaz.");
        }

        [Test]
        public void Customer_EmailIsEmpty_ShouldHaveError()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                Email = ""  
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email)
                  .WithErrorMessage("Email alaný boþ býrakýlamaz.");
        }

        [Test]
        public void Customer_IncorrectPhoneNumberFormat_ShouldHaveError()
        {
            // Arrange
            var customer = new CreateCustomerCommand
            {
                PhoneNumber = "1234567abc"  
            };

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
                  .WithErrorMessage("Telefon numarasý sadece rakamlardan oluþmalýdýr.");
        }
    }
}
