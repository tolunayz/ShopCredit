using FluentValidation;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;

namespace ShopCredit.Application.CQRS.Queries.CustomerAccountQueries
{
    public sealed class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerQueryValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.")
                .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Surname)
                .MaximumLength(100).WithMessage("Soy isim en fazla 100 karakter olabilir.")
                .MinimumLength(2).WithMessage("Soy isim en az 2 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Surname));

            RuleFor(x => x.PhoneNumber)
                .Length(10).WithMessage("Telefon numarası 10 haneli olmalıdır.")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçersiz Email formatı.")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
