import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LocacaoLivroComponent } from './locacao-livro.component';

describe('EmprestimoComponent', () => {
  let component: LocacaoLivroComponent;
  let fixture: ComponentFixture<LocacaoLivroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocacaoLivroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocacaoLivroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
