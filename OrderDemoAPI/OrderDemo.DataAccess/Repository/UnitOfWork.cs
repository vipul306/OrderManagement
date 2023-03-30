using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.DataAccess.Repository;
public class UnitOfWork : IUnitOfWork
{
    private ApplicationDBContext _dbContext;
    public UnitOfWork(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;
        Customer = new CustomerRepository(_dbContext);
        Product = new ProductRepository(_dbContext);
        OrderHeader = new OrderHeaderRepository(_dbContext);
        OrderDetail = new OrderDetailRepository(_dbContext);
    }
    public ICustomerRepository Customer { get; private set; }
    public IProductRepository Product { get; private set; }
    public IOrderHeaderRepository OrderHeader { get; private set; }
    public IOrderDetailRepository OrderDetail { get; private set; }
    public void Save()
    {
        _dbContext.SaveChanges();            
    }
}