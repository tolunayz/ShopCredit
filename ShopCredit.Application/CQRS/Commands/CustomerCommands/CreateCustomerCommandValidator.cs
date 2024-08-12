using FluentValidation;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.")
                .MinimumLength(3).WithMessage("İsim en az 3 karakter olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soy isim alanı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Soy isim en fazla 100 karakter olabilir.")
                .MinimumLength(3).WithMessage("Soy isim en az 3 karakter olmalıdır.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                .Length(10).WithMessage("Telefon numarası 10 haneli olmalıdır.")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçersiz Email.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Adres 200 karakterden uzun olamaz.");
        }
    }
}
