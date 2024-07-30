using MediatR;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler :IRequestHandler<CreateCustomerCommand,bool>
    {
        private readonly IWriteRepository<Customer> _writeRepository;


        public CreateCustomerCommandHandler(IWriteRepository<Customer> writerRepository)
        {
            _writeRepository = writerRepository;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.CreateAsync(Customer.Create(
            name: request.Name,
               surname: request.Surname,
               phoneNumber: request.PhoneNumber,
               email: request.Email
           ).SetAddress(address: request.Address));
            await _writeRepository.SaveAsync();

            return true;
        }
    }
}
