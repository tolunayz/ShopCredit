﻿using MediatR;
using ShopCredit.Application.Behaviors;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{

    private readonly IMediator _mediator;
    private readonly IShopCreditContext _con;

    public CreateCustomerCommandHandler(IMediator mediator, IShopCreditContext con/*, NotificationSender notificationSender*/)
    {
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

        await _con.Customers.AddAsync(customer);
        await _con.SaveChangesAsync(cancellationToken);
        await _mediator.Publish(new CustomerCreatedNotification(customer), cancellationToken);

        return true;
    }
}
