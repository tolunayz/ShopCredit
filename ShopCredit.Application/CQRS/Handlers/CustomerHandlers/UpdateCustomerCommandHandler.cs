using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IWriteRepository<Customer> _writeRepository;
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IPublisher _publisher;

        public UpdateCustomerCommandHandler
            (IRepository<Customer> repository,
            IReadRepository<Customer> readRepository,
            IWriteRepository<Customer> writeRepository,
            IPublisher publisher)
        {
            _repository = repository;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _publisher = publisher;
        }
        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.GetByIdAsync(request.CustomerID);
            customer.CustomerProperties
            (
                    request.Name,
                    request.Surname,
                    request.PhoneNumber,
                    request.Email,
                    request.Address
             );

            customer.Update(request.Name, request.Surname, request.PhoneNumber)
                    .SetAddress(request.Address)
                    .SetEmail(request.Email);

            await _writeRepository.Update(customer);
            await _writeRepository.SaveAsync();
            await _publisher.Publish(new CustomerUpdatedNotification(customer), cancellationToken);
            




        }
    }
}

