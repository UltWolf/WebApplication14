using AutoMapper;
using CQRSlite.Events;
using CQRSlite.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class OrderEventHandler: IEventHandler<CreateOrderEvent>,
                                    IEventHandler<ProductsAssignedToOrderEvent>,
                                    IEventHandler<ProductsRemovedFromOrdersEvent>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;
    public OrderEventHandler(IMapper mapper, IProductRepository productRepo,IOrderRepository orderRepo)
    {
        _mapper = mapper;
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

        public async Task Handle(CreateOrderEvent message)
        {
        OrderRM order = _mapper.Map<OrderRM>(message);

        _orderRepo.Save(order);
    }

  async Task IHandler<ProductsAssignedToOrderEvent>.Handle(ProductsAssignedToOrderEvent message)
        {
        var location = _orderRepo.GetByID(message.NewProductsID);
        location.Product.Add(message.NewProductsID);
        _orderRepo.Save(location);

        //Find the employee which was assigned to this Location
        var product =_productRepo.GetByID(message.OrderID);
        product.ProductId = message.NewProductsID;
        _productRepo.Save(product);
    }

       async Task IHandler<ProductsRemovedFromOrdersEvent>.Handle(ProductsRemovedFromOrdersEvent message)
    {
        var location = _orderRepo.GetByID(message.OldProductID);
        location.Product.Remove(message.OldProductID);
        _orderRepo.Save(location);
    }
      
    }
}
