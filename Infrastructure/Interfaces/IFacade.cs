using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Infrastructure.Interfaces
{
    interface IFacade
    {
        IEnumerable<Domain.Entities.Product> GetProducts();
    }
}
