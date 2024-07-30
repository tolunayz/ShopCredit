using MediatR;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IWriteRepository<Customer> _writeRepository;
        private readonly IReadRepository<Customer> _readRepository;

        public UpdateCustomerCommandHandler
            (IRepository<Customer> repository,
            IReadRepository<Customer> readRepository,
            IWriteRepository<Customer> writeRepository
            )
        {
            _repository = repository;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            //var values = await _readRepository.GetByIdAsync(command.AdminId);
            //values.AdminProperties(command.AdminName, command.AdminPassword);

            var values = await _readRepository.GetByIdAsync(request.CustomerID);
            values.CustomerProperties
            (
                    request.Name,
                    request.Surname,
                    request.PhoneNumber,
                    request.Email,
                    request.Address

                );

            await _writeRepository.Update(values);
            await _writeRepository.SaveAsync();
        }
    }
}
