import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralVariablesComponent } from './literal-variables.component';

describe('LiteralVariablesComponent', () => {
  let component: LiteralVariablesComponent;
  let fixture: ComponentFixture<LiteralVariablesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralVariablesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralVariablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
