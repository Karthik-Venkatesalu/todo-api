using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly Application.Product.Interfaces.IRequestHandler _requestHandler;

        public ProductController(Application.Product.Interfaces.IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [HttpGet]
        public IEnumerable<Domain.Entities.Product> Get()
        {
            return _requestHandler.GetProducts();      
        }
    }
}
