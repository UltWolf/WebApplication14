using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class ProductCommandHandler<T> : CQRSlite.Commands.ICommandHandler<CreateProductCommand>, 
                                            CQRSlite.Commands.ICommandHandler<AssignProductToOrderCommand>,
                                            CQRSlite.Commands.ICommandHandler<ProductRemoveFromOrdersCommand>
    {
        private readonly CQRSlite.Domain.ISession _session;


        public ProductCommandHandler(CQRSlite.Domain.ISession session)
        {
            _session = session;
        }


        public async Task Handle(CreateProductCommand message)
        {
            Product employee = new Product(message.Id,message.Category,message.Name,message.Country,message.Price,message.IsHave,message.Path);
         await  _session.Add(employee);
         await   _session.Commit();
                    
        }

        public async Task Handle(AssignProductToOrderCommand message)
        {
            Order order = await _session.Get<Order>(message.Id);
            order.AddProduct(message.NewProductsID);
            await _session.Commit();
        }


        public async Task Handle(ProductRemoveFromOrdersCommand message)
        {
            Order order = await _session.Get<Order>(message.Id);
            order.RemoveProduct(message.OldProductID );
            await _session.Commit();
        }

    }
}
