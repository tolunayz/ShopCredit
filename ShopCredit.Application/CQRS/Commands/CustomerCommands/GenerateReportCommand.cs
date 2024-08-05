using MediatR;

namespace ShopCredit.Application.CQRS.Commands
{
    public class GenerateReportCommand : IRequest
    {
        public Guid ReportId { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
