using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Infrastructure.Interfaces;

namespace ToDoAPI.Infrastructure.Services
{
    public class Facade : IFacade
    {
        private readonly Application.Product.Interfaces.IRequestHandler _productsRequestHandler;

        public Facade(Application.Product.Interfaces.IRequestHandler requestHandler)
        {
            _productsRequestHandler = requestHandler;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productsRequestHandler.GetProducts();
        }
    }
}
