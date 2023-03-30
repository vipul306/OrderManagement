import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/models/customer.model';
import { OrderHeader } from 'src/app/models/orderheader.model';
import { CustomerService } from 'src/app/services/customer.service';
import { OrderHeaderService } from 'src/app/services/orderheader.service';
import { OrderItemComponent } from './order-item/order-item.component';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  public customerList: Customer[] = [];
  public service: OrderHeaderService;
  public isValid: boolean = true;

  public orderIdControl: FormControl;
  public customerControl: FormControl;
  public grandTotalControl: FormControl;

  constructor(
    private newservice: OrderHeaderService,
    private dialog: MatDialog,
    private customerService: CustomerService,
    private toastr: ToastrService,
    private router: Router,
    private currentRoute: ActivatedRoute
  ) {
    this.service = newservice;

    this.orderIdControl = new FormControl('');
    this.customerControl = new FormControl('');
    this.grandTotalControl = new FormControl('');
  }

  ngOnInit(): void {
    this.customerService.getCustomerList().subscribe((response) => {
      response.forEach((e) => {
        this.customerList.push({
          Id: e.Id,
          Name: e.Name,
        });
      });
    });

    let orderID = this.currentRoute.snapshot.paramMap.get('id');
    if (orderID == null) this.resetForm();
    else {
      this.service.orderData = new OrderHeader();
      this.service.orderItems = [];
      this.service.getOrderByID(parseInt(orderID)).subscribe((response: any) => {
        this.service.orderData = <OrderHeader>response.OrderHeader;
        this.setForm(this.service.orderData);
        response.OrderDetail.forEach(
          (e: {
            Id: any;
            OrderId: any;
            Amount: any;
            ProductId: any;
            Quantity: any;
            Product: { Id: any; Price: any; Name: any };
          }) => {
            this.service.orderItems.push({
              Id: e.Id,
              OrderId: e.OrderId,
              Amount: e.Product.Price * e.Quantity,
              ProductId: e.ProductId,
              Quantity: e.Quantity,
              Price: e.Product.Price,
              ProductName: e.Product.Name,
              Product: e.Product,
            });
          }
        );
        this.updateGrandTotal();
      });
    }
  }

  public customerComparer(object1: Customer, object2: Customer): boolean {
    return object1 && object2 && object1.Id === object2.Id;
  }

  private setForm(order: OrderHeader) {
    this.orderIdControl.setValue(order.Id);
    this.customerControl.setValue(order.Customer);
    this.grandTotalControl.setValue(order.TotalAmount);
  }

  private resetForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.service.orderData = {
      Id: 0,
      CustomerId: 0,
      TotalAmount: 0,
      Customer: new Customer(),
    };
    this.service.orderItems = [];
  }

  public addOrEditOrderItem(Id: any, OrderID: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = '50%';
    dialogConfig.data = { Id, OrderID };
    this.dialog
      .open(OrderItemComponent, dialogConfig)
      .afterClosed()
      .subscribe((res) => {
        this.updateGrandTotal();
      });
  }

  public updateGrandTotal() {
    this.service.orderData.TotalAmount = this.service.orderItems.reduce(
      (prev :number, curr: any ) => {
        return prev + curr.Amount;
      },
      0
    );
    this.service.orderData.TotalAmount = parseFloat(
      this.service.orderData.TotalAmount.toFixed(2)
    );
  }

  public validateForm() {
    this.isValid = true;

    if (this.service.orderData.CustomerId == 0) this.isValid = false;
    else if (this.service.orderItems.length == 0) this.isValid = false;
    return this.isValid;
  }

  public updateCustomer(event: any) {
    this.service.orderData.Customer.Id = event.value;
  }

  public onSubmit(form: NgForm) {
    if (this.validateForm()) {
      this.service.saveOrUpdateOrder().subscribe((): void => {
        this.resetForm();
        this.toastr.success('Submitted Successfully', 'Order Demo.');
        this.router.navigate(['/']);
      });
    }
  }

  public viewOrder() {
    this.router.navigate(['/']);
  }
}
