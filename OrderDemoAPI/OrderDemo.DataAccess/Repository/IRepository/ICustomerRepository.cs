using OrderDemo.API.Model;

namespace OrderDemo.DataAccess.Repository.IRepository;
public interface ICustomerRepository: IRepository<Customer>
{
    void Update(Customer customer);
}
