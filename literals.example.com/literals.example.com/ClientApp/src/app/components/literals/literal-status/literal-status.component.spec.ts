import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralStatusComponent } from './literal-status.component';

describe('LiteralStatusComponent', () => {
  let component: LiteralStatusComponent;
  let fixture: ComponentFixture<LiteralStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
