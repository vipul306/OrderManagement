import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { OrderHeader } from 'src/app/models/orderheader.model';
import { OrderHeaderService  } from 'src/app/services/orderheader.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css'],
})
export class OrderListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  public displayedColumns: string[] = [
    'Id',
    'customerName',
    'totalAmount',
    'actions',
  ];
  public dataSource!: MatTableDataSource<OrderHeader>;
  public orderList: OrderHeader[] = [];

  constructor(private service: OrderHeaderService, private router: Router) {}

  ngOnInit(): void {
    this.refreshList();
  }

  private refreshList() {
    this.service.getOrderList().subscribe((res) => {
      this.orderList = res;
      this.dataSource = new MatTableDataSource(this.orderList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public onOrderDelete(order: OrderHeader) {}

  public openForEdit(orderID: number) {
    this.router.navigate(['/edit-food-order/' + orderID]);
  }

  public addNew() {
    this.router.navigate(['/add-food-order']);
  }
}
