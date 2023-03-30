import { Customer } from "./customer.model";

export class OrderHeader {
    Id: number;
    CustomerId: number;
    TotalAmount: number;
    
    Customer:Customer;
    constructor() {
        this.Id = 0;
        this.CustomerId = 0;
        this.TotalAmount = 0;
        this.Customer = new Customer();
    }
}
