import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { LocacaoLivroRoutingModule } from "./locacao-livro-routing.module";
import { LocacaoLivroComponent } from "./locacao-livro.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [LocacaoLivroComponent],
  imports: [CommonModule, LocacaoLivroRoutingModule, SharedModule],
})
export class LocacaoLivroModule {}
