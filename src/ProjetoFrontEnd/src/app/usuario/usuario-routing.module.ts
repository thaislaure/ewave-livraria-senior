import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { UsuarioCadastroComponent } from "./usuario-cadastro/usuario-cadastro.component";
import { UsuarioConsultaComponent } from "./usuario-consulta/usuario-consulta.component";

const routes: Routes = [
  {
    path: "",
    component: UsuarioConsultaComponent,
  },
  {
    path: "cadastrar",
    component: UsuarioCadastroComponent,
  },
  {
    path: ":id",
    component: UsuarioCadastroComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UsuarioRoutingModule {}
