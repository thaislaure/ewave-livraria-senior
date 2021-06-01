import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";
import { LivroService } from "../livro/livro.service";
import { UsuarioService } from "../usuario/usuario.service";
import { LocacaoLivroService } from "./locacao-livro.service";

@Component({
  selector: "app-locacao-livro",
  templateUrl: "./locacao-livro.component.html",
  styleUrls: ["./locacao-livro.component.scss"],
})
export class LocacaoLivroComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;

  subscription: Subscription;

  form: FormGroup;

  emprestimos = [];
  usuarios = [];
  livros = [];

  emprestimoId: string;

  submitted = false;

  data = new Date();
  constructor(
    private formBuilder: FormBuilder,
    private locacaoLivroService: LocacaoLivroService,
    private usuarioService: UsuarioService,
    private livroService: LivroService
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
    this.obterUsuarios();
    this.obterLivros();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      usuarioId: new FormControl('', [Validators.required]),
      livroId: new FormControl('', [Validators.required]),
      dataLocacao: new FormControl('', [Validators.required]),
      dataEntrega: new FormControl('', [Validators.required]),
    });
  }

  obter() {
    this.locacaoLivroService.obter().subscribe((res) => (this.emprestimos = res));
  }

  obterUsuarios() {
    this.usuarioService.obter().subscribe((res) => (this.usuarios = res));
  }

  obterLivros() {
    this.livroService.obter().subscribe((res) => (this.livros = res));
  }

  submit() {
    if (this.form.valid) {
      this.submitted = false;
      this.salvar();
    }

    this.submitted = true;
  }

  salvar() {
    const model = this.form.getRawValue();
    model.usuarioId = Number(model.usuarioId);
    model.livroId = Number(model.livroId);
    this.locacaoLivroService.criar(model).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  devolver(locacaoId) {
    this.locacaoLivroService.devolver(locacaoId).subscribe(() => this.obter());
  }

  abrirModal() {
    this.form.reset();
    this.modal.show();
  }

  fecharModal() {
    this.submitted = false;
    this.form.reset();
    this.modal.hide();
  }
}
