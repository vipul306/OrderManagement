namespace OrderDemo.DataAccess.Repository.IRepository;
public interface IUnitOfWork
{
    ICustomerRepository Customer { get; }
    IProductRepository Product { get; }
    IOrderHeaderRepository OrderHeader { get; }
    IOrderDetailRepository OrderDetail { get; }
    void Save();
}
