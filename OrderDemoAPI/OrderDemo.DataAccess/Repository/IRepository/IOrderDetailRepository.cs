using OrderDemo.API.Model;

namespace OrderDemo.DataAccess.Repository.IRepository;
public interface IOrderDetailRepository:IRepository<OrderDetail>
{
    void Update(OrderDetail orderDetail);
}
