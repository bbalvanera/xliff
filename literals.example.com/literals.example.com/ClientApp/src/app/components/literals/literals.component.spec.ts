import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralsComponent } from './literals.component';

describe('LiteralsComponent', () => {
  let component: LiteralsComponent;
  let fixture: ComponentFixture<LiteralsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
