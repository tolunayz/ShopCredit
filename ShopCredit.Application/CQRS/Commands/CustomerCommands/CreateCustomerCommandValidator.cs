using FluentValidation;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {

        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş bıraklamaz.")
                .MaximumLength(100).MinimumLength(3).WithMessage("En az 3 en fazla 100 karakter girilebilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim alanı boş bırakılamaz.")
                .MaximumLength(100)
                .MinimumLength(3).WithMessage("En az 3 en fazla 100 karakter girilebilir.");



            RuleFor(x => x.PhoneNumber)
                .GreaterThan(0).WithMessage("Telefon numarası 0 olamaz.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçersiz Email.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Karakter sınırı 200.");
        }
    }
}
