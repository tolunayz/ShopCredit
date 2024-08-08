using MediatR;
using RabbitMQ.Client;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Application.Services;
using ShopCredit.Domain.Entities;
using System.Text;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly IWriteRepository<Customer> _writeRepository;
    private readonly IMediator _mediator;
    private readonly IShopCreditContext _con;
    private readonly NotificationSender _notificationSender;


    public CreateCustomerCommandHandler(IWriteRepository<Customer> writeRepository, IMediator mediator, IShopCreditContext con, NotificationSender notificationSender)
    {
        _writeRepository = writeRepository;
        _mediator = mediator;
        _con = con;
        _notificationSender = notificationSender;
    }

    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            name: request.Name,
            surname: request.Surname,
            phoneNumber: request.PhoneNumber,
            email: request.Email
        ).SetAddress(request.Address);

        await _con.Customers.AddAsync(customer);
        await _con.SaveChangesAsync(cancellationToken);
        await _mediator.Publish(new CustomerCreatedNotification(customer), cancellationToken);

        //_notificationSender.SendNotification("sdsds");
        ////await Task.Delay(5000);
        ////_notificationSender.ReadNotification("reading");
      
        
        return true;
    }
}
