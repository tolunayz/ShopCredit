using MediatR;
using ShopCredit.Application.CQRS.Commands.CustomerAccountCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

public class PaymentCommandHandler : IRequestHandler<PaymentCommand>
{
    private readonly IReadRepository<CustomerAccount> _readRepository;
    private readonly IWriteRepository<CustomerAccount> _writeRepository;

    public PaymentCommandHandler(IReadRepository<CustomerAccount> readRepository, IWriteRepository<CustomerAccount> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(PaymentCommand paymentRequest, CancellationToken cancellationToken)
    {
        var customerAccount = await _readRepository.GetByIdAsync(paymentRequest.AccountId);

        if (customerAccount != null)
        {
         
            if (paymentRequest.PaidDebt > customerAccount.CurrentDebt)
            {
                throw new InvalidOperationException("Ödenen borç, kalan borçtan büyük olamaz.");
            }

            CustomerAccount.SetPaidDebt(
                customerAccount,
                paidDebt: paymentRequest.PaidDebt
            );

            await _writeRepository.Update(customerAccount);
            await _writeRepository.SaveAsync();
        }


    }
}
