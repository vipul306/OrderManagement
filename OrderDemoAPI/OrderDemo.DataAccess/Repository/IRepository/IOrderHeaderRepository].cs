using OrderDemo.API.Model;

namespace OrderDemo.DataAccess.Repository.IRepository;
public interface IOrderHeaderRepository: IRepository<OrderHeader>
{
    void Update(OrderHeader orderHeader);
}
