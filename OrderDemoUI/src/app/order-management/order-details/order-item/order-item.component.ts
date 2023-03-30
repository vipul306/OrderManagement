import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderHeaderService } from 'src/app/services/orderheader.service';
import { ProductService } from 'src/app/services/product.service';
import { FormControl, NgForm } from '@angular/forms';
import { OrderDetail } from 'src/app/models/orderdetail.model';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: [],
})
export class OrderItemComponent implements OnInit {
  public fromData: OrderDetail = new OrderDetail();
  public itemList: Product[] = [];
  public isValid: boolean = true;



  constructor(
    @Inject(MAT_DIALOG_DATA) public data: OrderDetail,
    public dialogRef: MatDialogRef<OrderItemComponent>,
    private productService: ProductService,
    private orderSevice: OrderHeaderService
  ) {}
  ngOnInit(): void {
    this.productService
      .getProductList()
      .subscribe((res) => (this.itemList = res));
    if (this.data.Id == null) {
      this.fromData = {
        Id: 0,
        OrderId: this.data.OrderId == null ? 0 : this.data.OrderId,
        ProductId: 0,
        Quantity: 0,
        Amount: 0,
        Price: 0,
        ProductName: '',
        Product: new Product(),
      };
    } else {
      this.fromData = Object.assign(
        {},
        this.orderSevice.orderItems[this.data.Id]
      );
    }
  }

  public onSubmit(form: NgForm) {
    if (this.validateForm(form.value)) {
      if (this.data.Id == null) {
        this.orderSevice.orderItems.push(form.value);
      } else this.orderSevice.orderItems[this.data.Id] = form.value;
      this.dialogRef.close();
    }
  }



  private validateForm(formData: OrderDetail) {
    this.isValid = true;
    if (formData.Id == 0) this.isValid = true;
    else if (formData.Quantity == 0) this.isValid = false;
    return this.isValid;
  }

  public updatePrice(ctrl: any) {
    if (ctrl.selectedIndex == 0) {
      this.fromData.Price = 0;
      this.fromData.ProductName = '';
    } else {
      this.fromData.Price = this.itemList[ctrl.selectedIndex - 1].Price;
      this.fromData.ProductName = this.itemList[ctrl.selectedIndex - 1].Name;
    }
    this.updateTotal();
  }

  public updateTotal() {
    this.fromData.Amount = parseFloat(
      (this.fromData.Quantity * this.fromData.Price).toFixed(2)
    );
  }
}
