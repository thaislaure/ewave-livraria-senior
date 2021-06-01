import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../shared/http.service";

@Injectable({
  providedIn: "root",
})
export class LivroService extends HttpService {
  constructor(public injector: Injector) {
    super(injector, "livro", "livro");
  }

  public obter() {
    return this.get();
  }

  public obterPorId(id: string) {
    return this.get(id);
  }

  public criar(body: any) {
    return this.post(null, body);
  }

  public alterar(id: string, body: any) {
    return this.put(id, body);
  }

  public inativarAtivar(id, ativo) {
    return this.inativarOuAtivar(id, ativo);
  }
}
