import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { OrderManagementComponent } from './order-management.component';


describe('OrderManagementComponent', () => {
  let component: OrderManagementComponent;
    let fixture: ComponentFixture<OrderManagementComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [ OrderManagementComponent ],
            imports: [
                RouterTestingModule
            ]
        })
            .compileComponents();

        fixture = TestBed.createComponent(OrderManagementComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
