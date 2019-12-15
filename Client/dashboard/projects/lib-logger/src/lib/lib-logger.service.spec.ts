import { TestBed } from '@angular/core/testing';

import { LibLoggerService } from './lib-logger.service';

describe('LibLoggerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LibLoggerService = TestBed.get(LibLoggerService);
    expect(service).toBeTruthy();
  });
});
