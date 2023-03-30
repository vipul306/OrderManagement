using OrderDemo.API.Model;
using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.DataAccess.Repository;
public class ProductRepository : Repository<Product>, IProductRepository
{
    private ApplicationDBContext _dbContext;
    public ProductRepository(ApplicationDBContext dBContext) : base(dBContext) 
    {
        _dbContext = dBContext;
    }
    public void Update(Product product)
    {
        var objProduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        if(objProduct != null)
        {
            objProduct.Name = product.Name;
            objProduct.Price = product.Price;
        }
    }
}
