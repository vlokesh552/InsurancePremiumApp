import { TestBed } from '@angular/core/testing';

import { UserPremiumService } from './user-premium.service';

describe('UserPremiumService', () => {
  let service: UserPremiumService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserPremiumService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
