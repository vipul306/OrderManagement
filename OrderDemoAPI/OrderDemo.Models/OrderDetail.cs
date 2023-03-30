﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDemo.API.Model;
public class OrderDetail
{
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [ValidateNever]
    public OrderHeader OrderHeader { get; set; }
    [Required]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }

    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }
}
    
