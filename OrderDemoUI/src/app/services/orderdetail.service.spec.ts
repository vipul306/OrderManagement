import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { OrderdetailService } from './orderdetail.service';

describe('OrderdetailService', () => {
  let service: OrderdetailService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientModule],
        });
        service = TestBed.inject(OrderdetailService);
    });

    it("should be created", () => {
        expect(service).toBeTruthy();
    });
});
