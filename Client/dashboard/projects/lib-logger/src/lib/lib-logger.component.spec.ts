import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LibLoggerComponent } from './lib-logger.component';

describe('LibLoggerComponent', () => {
  let component: LibLoggerComponent;
  let fixture: ComponentFixture<LibLoggerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LibLoggerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LibLoggerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
