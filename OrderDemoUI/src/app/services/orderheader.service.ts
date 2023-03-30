import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrderDetail } from '../models/orderdetail.model';
import { OrderHeader } from '../models/orderheader.model';

@Injectable({
  providedIn: 'root',
})
export class OrderHeaderService {
  public orderData: OrderHeader = new OrderHeader();
  public orderItems: OrderDetail[] = [];

  constructor(private http: HttpClient) {}

  public getOrderList(): Observable<OrderHeader[]> {
    return this.http.get<OrderHeader[]>(environment.apiURL + '/Order');
  }

  public getOrderByID(id: number): Observable<any> {
    return this.http.get<any>(environment.apiURL + '/Order/' + id).pipe(
      map((res) => res),
      catchError((err) => throwError(err))
    );
  }

  public saveOrUpdateOrder() {
    var body = {
      OrderHeader: this.orderData,
      OrderDetail: this.orderItems,
    };
    return this.http.post(environment.apiURL + '/Order', body);
  }

  public saveOrder() {
    var body = {
      ...this.orderData,
      OrderItems: this.orderItems,
    };
    return this.http.post(environment.apiURL + '/SaveOrder', body);
  }

  public updateOrder() {
    var body = {
      ...this.orderData,
      OrderItems: this.orderItems,
    };
    return this.http.post(environment.apiURL + '/UpdateOrder', body);
  }

  public deleteOrder() {
    var body = {
      OrderHeader: this.orderData,
      OrderDetail: this.orderItems,
    };
    return this.http.delete(environment.apiURL + 'Order');
  }
}
