using AutoMapper;
using CQRSlite.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class ProductEventHandler: CQRSlite.Events.IEventHandler<CreateProductEvent>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        public ProductEventHandler(IMapper mapper, IProductRepository employeeRepo)
        {
            _mapper = mapper;
            _productRepo = employeeRepo;
        }

    
             async Task IHandler<CreateProductEvent>.Handle(CreateProductEvent message)
        {
            ProductRM products = _mapper.Map<ProductRM>(message);
            _productRepo.Save(products);
        }
    }
}
