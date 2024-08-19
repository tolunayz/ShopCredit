using MediatR;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class UpdateAdminCommand : IRequest
    {
        public UpdateAdminCommand(Guid adminId, string adminName, string adminPassword)
        {
            AdminId = adminId;
            AdminName = adminName;
            AdminPassword = adminPassword;
        }

        public Guid AdminId { get; set; }
        public required string AdminName { get; set; }
        public required string AdminPassword { get; set; }
    }
}
