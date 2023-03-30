using OrderDemo.API.Model;
using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.DataAccess.Repository;
public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
{
    private ApplicationDBContext _dbContext;
    public OrderHeaderRepository(ApplicationDBContext dBContext): base(dBContext) 
    {
        _dbContext = dBContext;
    }

    public void Update(OrderHeader orderHeader)
    {
        _dbContext.OrderHeaders.Update(orderHeader);
    }
}
