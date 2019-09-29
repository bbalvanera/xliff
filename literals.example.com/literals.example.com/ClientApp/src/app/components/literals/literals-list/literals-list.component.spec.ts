import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralsListComponent } from './literals-list.component';

describe('LiteralsListComponent', () => {
  let component: LiteralsListComponent;
  let fixture: ComponentFixture<LiteralsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
