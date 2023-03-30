using OrderDemo.API.Model;
using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.DataAccess.Repository;
public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    private ApplicationDBContext _dbContext;
    public OrderDetailRepository(ApplicationDBContext dBContext): base(dBContext)
    {
        _dbContext = dBContext;
    }
    public void Update(OrderDetail orderDetail)
    {
        _dbContext.OrderDetails.Update(orderDetail);
    }
}
