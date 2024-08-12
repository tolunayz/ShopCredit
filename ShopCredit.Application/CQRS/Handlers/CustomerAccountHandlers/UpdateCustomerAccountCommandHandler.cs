using MediatR;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class UpdateCustomerAccountCommandHandler : IRequestHandler<UpdateCustomerAccountCommand>
    {
        private readonly IWriteRepository<CustomerAccount> _writeRepository;
        private readonly IReadRepository<CustomerAccount> _readRepository;
        private readonly IReadRepository<Customer> _customerReadRepository;

        public UpdateCustomerAccountCommandHandler(IWriteRepository<CustomerAccount> writeRepository, IReadRepository<CustomerAccount> readRepository, IReadRepository<Customer> customerReadRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _customerReadRepository = customerReadRepository;
        }
        public async Task Handle(UpdateCustomerAccountCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.CustomerId);
            var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
            values.CustomerAccountProperties
            (
               
                request.IsPaid,
                request.Description,
                request.CurrentDebt,
                request.Debt,
                request.PaidDebt
                );

            await _writeRepository.Update(values);
            await _writeRepository.SaveAsync();
        }
    }
}
