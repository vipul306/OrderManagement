using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDemo.API.Model;
public class OrderHeader
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    [ValidateNever]
    public Customer Customer { get; set; }

    public decimal TotalAmount { get; set; }
}
