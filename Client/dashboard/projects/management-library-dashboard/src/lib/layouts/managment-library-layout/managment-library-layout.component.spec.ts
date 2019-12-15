import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagmentLibraryLayoutComponent } from './managment-library-layout.component';

describe('ManagmentLibraryLayoutComponent', () => {
  let component: ManagmentLibraryLayoutComponent;
  let fixture: ComponentFixture<ManagmentLibraryLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagmentLibraryLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagmentLibraryLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
