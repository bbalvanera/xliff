import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralValuesComponent } from './literal-values.component';

describe('LiteralValuesComponent', () => {
  let component: LiteralValuesComponent;
  let fixture: ComponentFixture<LiteralValuesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralValuesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
