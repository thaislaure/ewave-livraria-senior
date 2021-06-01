import { Observable } from "rxjs";
import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../shared/http.service";

@Injectable({
  providedIn: "root",
})
export class AutorService extends HttpService {
  constructor(public injector: Injector) {
    super(injector, "autor", "autor");
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

  public inativarOuAtivar(id: string) {
    return this.put(`${id}/inativarOuAtivar`, null);
  }

  public excluir(id: string) {
    return this.delete(`${id}`);
  }
}
