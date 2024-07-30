using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler
    {
        private readonly IWriteRepository<Customer> _writeRepository;


        public CreateCustomerCommandHandler(IWriteRepository<Customer> writerRepository)
        {
            _writeRepository = writerRepository;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            await _writeRepository.CreateAsync(Customer.Create(
                name: command.Name,
                surname: command.Surname,
                phoneNumber: command.PhoneNumber,
                email: command.Email
            ).SetAddress(address:command.Address));
            await _writeRepository.SaveAsync();
        }
      
    }
}
