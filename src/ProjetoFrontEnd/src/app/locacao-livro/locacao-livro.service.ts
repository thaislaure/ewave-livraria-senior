import { Injectable, Injector } from "@angular/core";
import { HttpService } from "../shared/http.service";

@Injectable({
  providedIn: "root",
})
export class LocacaoLivroService extends HttpService {
  constructor(
    public injector: Injector,
    ) {
    super(injector, "LocacaoLivro", "LocacaoLivro");
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

}
