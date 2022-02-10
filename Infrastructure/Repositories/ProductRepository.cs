using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;
using Dapper;

namespace ToDoAPI.Infrastructure.Repositories
{
    public class ProductRepository : Application.Product.Interfaces.IRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            using (var sqlConnection = new SqlConnection(Configuration.GetDBConnectionString()))
            {
                sqlConnection.Open();
                var result = sqlConnection.Query<Product>("select ProductID, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock from dbo.Products;");
                return result;
            }
        }
    }
}
