import { TestBed, inject } from '@angular/core/testing';

import { WorkDaysService } from './work-days.service';

describe('WorkDaysService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkDaysService]
    });
  });

  it('should be created', inject([WorkDaysService], (service: WorkDaysService) => {
    expect(service).toBeTruthy();
  }));
});
