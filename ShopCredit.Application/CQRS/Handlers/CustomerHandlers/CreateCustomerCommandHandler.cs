using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.CQRS.Handlers.NotificationHandlers;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly IWriteRepository<Customer> _writeRepository;
    private readonly IMediator _mediator;
    private readonly IShopCreditContext _con;
   

    public CreateCustomerCommandHandler(IWriteRepository<Customer> writeRepository, IMediator mediator, IShopCreditContext con)
    {
        _writeRepository = writeRepository;
        _mediator = mediator;
        _con = con;
    }

    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            name: request.Name,
            surname: request.Surname,
            phoneNumber: request.PhoneNumber,
            email: request.Email
        ).SetAddress(request.Address);


        //await _con.CreateAsync(customer);
        await _con.Customers.AddAsync(customer);
        await _con.SaveChangesAsync(cancellationToken);
        customer.SendEmail(customer.Name, customer.Email);
        await _mediator.Publish(new CustomerCreatedNotification(customer), cancellationToken);
        return true;
    }
}
