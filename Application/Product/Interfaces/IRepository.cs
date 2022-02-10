using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Application.Product.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Domain.Entities.Product> GetProducts();
    }
}
