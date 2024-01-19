using DBContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.DataBase
{
    public class DataBaseFixture : IDisposable
    {
        private readonly SqliteConnection _connection;
        public DataBaseFixture()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public ProductsAPIContext CreateContext()
        {
            var result = new ProductsAPIContext(new DbContextOptionsBuilder<ProductsAPIContext>()
                .UseSqlite(_connection)
                .Options);

            result.Database.EnsureCreated();
            return result;
        }
    }
}
