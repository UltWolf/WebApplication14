using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class OrderCommandHandler : CQRSlite.Commands.ICommandHandler<CreateOrderCommand>
    {
        private readonly CQRSlite.Domain.ISession _session;

        OrderCommandHandler(CQRSlite.Domain.ISession session) { this._session = session; }

        public async  Task Handle(CreateOrderCommand message)
        {
            var order = new Order(message.Id,message.Product,message.UserId,message.Count,message.IsConfirm,message.TotalCost );
            await _session.Add(order);
            await _session.Commit();
        }
    }
}
