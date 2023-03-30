
using Microsoft.EntityFrameworkCore;
using OrderDemo.API.Model;

namespace OrderDemo.DataAccess.Data;
public class ApplicationDBContext : DbContext
{ 
    public ApplicationDBContext(DbContextOptions options)
        : base(options) { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "William" },
            new Customer { Id = 2, Name = "John" },
            new Customer { Id = 3, Name = "Sachin" },
            new Customer { Id = 4, Name = "Daniel" },
            new Customer { Id = 5, Name = "Sunil" },
            new Customer { Id = 6, Name = "Jersy" },
            new Customer { Id = 7, Name = "Computer1" },
            new Customer { Id = 8, Name = "Computer2" },
            new Customer { Id = 9, Name = "Computer3" },
            new Customer { Id = 10, Name = "Computer4" },
            new Customer { Id = 11, Name = "Computer5" },
            new Customer { Id = 12, Name = "Computer6" },
            new Customer { Id = 13, Name = "Computer7" },
            new Customer { Id = 14, Name = "Computer8" },
            new Customer { Id = 15, Name = "Computer9" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Computer", Price = 50700.00 },
            new Product { Id = 2, Name = "LapTop", Price = 65000.00 },
            new Product { Id = 3, Name = "CPU", Price = 45000.00 },
            new Product { Id = 4, Name = "UPS", Price = 12500.00 },
            new Product { Id = 5, Name = "Network Switch", Price = 37500.00 }
        );

        modelBuilder.Entity<OrderHeader>().HasData(
               new OrderHeader { Id = 1, CustomerId = 1, TotalAmount = Convert.ToDecimal(12.15) },
               new OrderHeader { Id = 2, CustomerId = 2, TotalAmount = Convert.ToDecimal(20.00) },
               new OrderHeader { Id = 3, CustomerId = 3, TotalAmount = Convert.ToDecimal(92.50) },
               new OrderHeader { Id = 4, CustomerId = 4, TotalAmount = Convert.ToDecimal(24.25) },
               new OrderHeader { Id = 5, CustomerId = 5, TotalAmount = Convert.ToDecimal(27.89) },
               new OrderHeader { Id = 6, CustomerId = 6, TotalAmount = Convert.ToDecimal(610.00) },
               new OrderHeader { Id = 7, CustomerId = 7, TotalAmount = Convert.ToDecimal(1000.16) },
               new OrderHeader { Id = 8, CustomerId = 8, TotalAmount = Convert.ToDecimal(85.74)},
               new OrderHeader { Id = 9, CustomerId = 10, TotalAmount = Convert.ToDecimal(78.94) },
               new OrderHeader { Id = 10, CustomerId = 10, TotalAmount = Convert.ToDecimal(78.94) },
               new OrderHeader { Id = 11, CustomerId = 11, TotalAmount = Convert.ToDecimal(38.95) },
               new OrderHeader { Id = 12, CustomerId = 12, TotalAmount = Convert.ToDecimal(156.17) },
               new OrderHeader { Id = 13, CustomerId = 13, TotalAmount = Convert.ToDecimal(139.38) },
               new OrderHeader { Id = 14, CustomerId = 14, TotalAmount = Convert.ToDecimal(34.84) }
           );

        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { Id = 1, OrderId= 1, ProductId = 1, Quantity = 1, Amount = Convert.ToDecimal(12.15) },
            new OrderDetail { Id = 2, OrderId= 2, ProductId = 2, Quantity = 1, Amount = Convert.ToDecimal(20.00) },
            new OrderDetail { Id = 3, OrderId= 3, ProductId = 3, Quantity = 1, Amount = Convert.ToDecimal(92.50) },
            new OrderDetail { Id = 4, OrderId= 4, ProductId = 4, Quantity = 1, Amount = Convert.ToDecimal(24.25) },
            new OrderDetail { Id = 5, OrderId= 5, ProductId = 5, Quantity = 1, Amount = Convert.ToDecimal(27.89) },
            new OrderDetail { Id = 6, OrderId= 6, ProductId = 1, Quantity = 1, Amount = Convert.ToDecimal(610.00) },
            new OrderDetail { Id = 7, OrderId= 7, ProductId = 2, Quantity = 1, Amount = Convert.ToDecimal(1000.16) },
            new OrderDetail { Id = 8, OrderId= 8, ProductId = 3, Quantity = 1, Amount = Convert.ToDecimal(85.74) },
            new OrderDetail { Id = 9, OrderId= 9, ProductId = 4, Quantity = 1, Amount = Convert.ToDecimal(52.50) },
            new OrderDetail { Id = 10,OrderId = 10, ProductId = 5, Quantity = 1, Amount = Convert.ToDecimal(66.79) },
            new OrderDetail { Id = 11,OrderId = 11, ProductId = 1, Quantity = 1, Amount = Convert.ToDecimal(18.95) },
            new OrderDetail { Id = 12,OrderId = 12, ProductId = 2, Quantity = 1, Amount = Convert.ToDecimal(63.67) },
            new OrderDetail { Id = 13,OrderId = 13, ProductId = 3, Quantity = 2, Amount = Convert.ToDecimal(139.38) },
            new OrderDetail { Id = 14,OrderId = 14, ProductId = 4, Quantity = 2, Amount = Convert.ToDecimal(138.34) }          
        );
    }
}
