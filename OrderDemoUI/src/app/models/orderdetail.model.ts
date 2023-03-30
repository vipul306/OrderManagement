import { Product } from "./product.model";

export class OrderDetail {
    Id: number;
    OrderId: number;
    ProductId: number;
    ProductName: string = "";
    Quantity: number;
    Price: number;
    Amount: number;
    Product:  Product;
    constructor() { 
        this.Id = 0;
        this.OrderId = 0;
        this.ProductId = 0;
        this.ProductName = "";
        this.Quantity = 0;
        this.Price = 0;
        this.Amount = 0;
        this.Product = new Product();
    }
}
