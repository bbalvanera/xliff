import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiteralAddComponent } from './literal-add.component';

describe('LiteralAddComponent', () => {
  let component: LiteralAddComponent;
  let fixture: ComponentFixture<LiteralAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiteralAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiteralAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
