import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseFormDialogComponent } from './course-form-dialog.component';

describe('CourseFormDialogComponent', () => {
  let component: CourseFormDialogComponent;
  let fixture: ComponentFixture<CourseFormDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CourseFormDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
