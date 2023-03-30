using Microsoft.AspNetCore.Mvc;
using OrderDemo.API.Model;
using OrderDemo.DataAccess.Repository.IRepository;
using OrderDemo.Models.ViewModel;

namespace OrderDemo.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderDTO OrderVM { get; set; }

    public OrderController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "Customer");
        return Ok(orderHeaders);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Get([FromRoute]int id)
    {
        OrderVM = new OrderDTO()
        {
            OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "Customer"),
            OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == id, includeProperties: "Product"),
        };
        return Ok(OrderVM);
    }

    [HttpPost]
    public IActionResult Post([FromBody] OrderDTO orderDTO)
    {
        if (orderDTO == null)
        {
            return BadRequest("Order is null");
        }
        if(orderDTO.OrderHeader.Id == 0 )
        {
            orderDTO.OrderHeader.Customer = null;
            _unitOfWork.OrderHeader.Add(orderDTO.OrderHeader);
            _unitOfWork.Save();
            foreach (var item in orderDTO.OrderDetail)
            {
                item.Product = null;
                item.OrderId = orderDTO.OrderHeader.Id;
                _unitOfWork.OrderDetail.Add(item);
                _unitOfWork.Save();
            }
        }
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] OrderHeader orderHeader)
    {
        if (orderHeader == null)
        {
            return BadRequest("Order is null");
        }
        _unitOfWork.OrderHeader.Update(orderHeader);
        _unitOfWork.Save();
        return Ok();
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] OrderHeader orderHeader)
    {
        if (orderHeader == null)
        {
            return BadRequest("Order is null");
        }
        _unitOfWork.OrderHeader.Remove(orderHeader);
        _unitOfWork.Save();
        return Ok();
    }
}
