import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { OrderheaderService } from './orderheader.service';

describe('OrderheaderService', () => {
  let service: OrderheaderService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    });
    service = TestBed.inject(OrderheaderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
