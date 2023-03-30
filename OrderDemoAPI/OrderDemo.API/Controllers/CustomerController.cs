using Microsoft.AspNetCore.Mvc;
using OrderDemo.API.Model;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customerList = _unitOfWork.Customer.GetAll();
        return Ok(customerList);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Get([FromRoute] int  id)
    {
        var customer = _unitOfWork.Customer.GetFirstOrDefault(p => p.Id == id);
        return Ok(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Customer is null");
        }
        _unitOfWork.Customer.Add(customer);
        _unitOfWork.Save();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Customer is null");
        }
        _unitOfWork.Customer.Update(customer);
        _unitOfWork.Save();
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Customer is null");
        }
        _unitOfWork.Customer.Remove(customer);
        _unitOfWork.Save();
        return Ok();
    }
}

