using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderDemo.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDemo.DataAccess.Data
{
    public class DbInitializer
    {
        readonly ApplicationDBContext _context;
        readonly ILogger _logger;
        public DbInitializer(ApplicationDBContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Run()
        {
            _context.Database.Migrate();
        }

        private async Task SeedDemoDataAsync()
        {
            if(!await _context.Customers.AnyAsync() && !await _context.Products.AnyAsync())
            {
                _logger.LogInformation("Inserting Demo Data Started");
                Customer customer_1 = new Customer
                {
                    Name = "John Doe"
                };
                Customer customer_2 = new Customer
                {
                    Name = "John Doe"
                };
                _logger.LogInformation("Inserting Demo Data Completed");

            }
        }
    }
}
