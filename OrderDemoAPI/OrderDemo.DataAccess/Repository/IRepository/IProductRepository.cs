using OrderDemo.API.Model;

namespace OrderDemo.DataAccess.Repository.IRepository;
public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
}
