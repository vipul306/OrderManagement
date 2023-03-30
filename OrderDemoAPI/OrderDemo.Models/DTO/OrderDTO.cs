using OrderDemo.API.Model;

namespace OrderDemo.Models.ViewModel;
public class OrderDTO
{
    public OrderHeader OrderHeader { get; set; }
    public IEnumerable<OrderDetail> OrderDetail { get; set; }
}
