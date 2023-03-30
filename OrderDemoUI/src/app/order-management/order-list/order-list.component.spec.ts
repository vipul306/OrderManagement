import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterTestingModule } from '@angular/router/testing';
import { OrderListComponent } from './order-list.component';



describe('OrderListComponent', () => {
  let component: OrderListComponent;
  let fixture: ComponentFixture<OrderListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        declarations: [ OrderListComponent ],
        imports: [
            RouterTestingModule, HttpClientModule, MatToolbarModule, CommonModule
        ]
    })
        .compileComponents();

    fixture = TestBed.createComponent(OrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
});

it("should create", () => {
    expect(component).toBeTruthy();
});
});
