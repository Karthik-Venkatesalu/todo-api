using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Infrastructure.Repositories
{
    public static class Configuration
    {
        public static string GetDBConnectionString()
        {
            return @"Server=localhost\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
        }
    }
}
