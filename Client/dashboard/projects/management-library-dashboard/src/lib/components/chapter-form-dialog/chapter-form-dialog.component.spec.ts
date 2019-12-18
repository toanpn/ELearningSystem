import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChapterFormDialogComponent } from './chapter-form-dialog.component';

describe('ChapterFormDialogComponent', () => {
  let component: ChapterFormDialogComponent;
  let fixture: ComponentFixture<ChapterFormDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChapterFormDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChapterFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
