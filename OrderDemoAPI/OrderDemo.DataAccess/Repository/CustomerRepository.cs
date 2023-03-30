using OrderDemo.API.Model;
using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.DataAccess.Repository;
public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private ApplicationDBContext _dbContext;
    public CustomerRepository(ApplicationDBContext dBContext): base(dBContext) 
    {
        _dbContext = dBContext;
    }
    public void Update(Customer customer)
    {
        _dbContext.Customers.Update(customer);
    }
}
