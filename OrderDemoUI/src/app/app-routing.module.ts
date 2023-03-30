import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderDetailsComponent } from './order-management/order-details/order-details.component';
import { OrderListComponent } from './order-management/order-list/order-list.component';


import { OrderManagementComponent } from './order-management/order-management.component';

const routes: Routes = [
  {
    path: '',
    component: OrderManagementComponent,
    children: [
      { path: '', component: OrderListComponent },
      { path: 'add-food-order', component: OrderDetailsComponent },
      { path: 'edit-food-order/:id', component: OrderDetailsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
