using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Application.Product.Interfaces;

namespace ToDoAPI.Application.Product
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IRepository _productRepository;

        public RequestHandler(IRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Domain.Entities.Product> GetProducts()
        {
            return _productRepository.GetProducts().ToList();
        }
    }
}
