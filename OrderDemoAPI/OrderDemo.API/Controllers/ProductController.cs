using Microsoft.AspNetCore.Mvc;
using OrderDemo.API.Model;
using OrderDemo.DataAccess.Repository.IRepository;

namespace OrderDemo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var productList =  _unitOfWork.Product.GetAll();
        return Ok(productList);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Get([FromRoute]int id)
    {
        var product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
        return Ok(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post([FromBody] Product product)
    {
        if(product == null)
        {
            return BadRequest("Product is null");
        }
        _unitOfWork.Product.Add(product);
        _unitOfWork.Save();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Product product)
    {
        if(product == null)
        {
            return BadRequest("Product is null");
        }
        _unitOfWork.Product.Update(product);
        _unitOfWork.Save();
        return Ok();
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] Product product)
    {
        if(product == null)
        {
            return BadRequest("Product is null");

        }
        _unitOfWork.Product.Remove(product);
        _unitOfWork.Save();
        return Ok();
    }
}
