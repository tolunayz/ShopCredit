using MediatR;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand>
    {

        private readonly IReadRepository<Admin> _readRepository;
        private readonly IWriteRepository<Admin> _writeRepository;

        public UpdateAdminCommandHandler(IWriteRepository<Admin> writeRepository, IReadRepository<Admin> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.AdminId);
            values.AdminProperties
                (
                request.AdminName, 
                request.AdminPassword
                );
            await _writeRepository.Update(values);
            await _writeRepository.SaveAsync();
        }
    }
}


//public async Task Handle(UpdateCustomerAccountCommand request, CancellationToken cancellationToken)
//{
//    var values = await _readRepository.GetByIdAsync(request.CustomerId);
//    var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
//    values.CustomerAccountProperties
//    (

//        request.IsPaid,
//        request.Description,
//        request.CurrentDebt,
//        request.Debt,
//        request.PaidDebt
//        );

//    await _writeRepository.Update(values);
//    await _writeRepository.SaveAsync();
//}
//    }