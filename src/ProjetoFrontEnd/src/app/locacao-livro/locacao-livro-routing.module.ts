import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LocacaoLivroComponent } from './locacao-livro.component';

const routes: Routes = [
  {
    path: '',
    component: LocacaoLivroComponent,
    data: {
      title: 'Locação de Livros'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LocacaoLivroRoutingModule { }
