import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

import { AutorService } from "../autor/autor.service";
import { GeneroService } from "../genero/genero.service";
import { LivroService } from "./livro.service";

@Component({
  selector: "app-livro",
  templateUrl: "./livro.component.html",
  styleUrls: ["./livro.component.scss"],
})
export class LivroComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;
  @ViewChild("arquivoInput") arquivoInput: ElementRef;

  subscription: Subscription;

  form: FormGroup;

  livroId: string;

  livros = [];
  autores = [];
  generos = [];

  editar = false;
  submitted = false;

  constructor(
    private livroService: LivroService,
    private autorService: AutorService,
    private generoService: GeneroService,
    private formBuilder: FormBuilder
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
    this.obterAutores();
    this.obterGeneros();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      titulo: [null, Validators.required],
      generoId: [null, Validators.required],
      autorId: [null, Validators.required],
      sinopse: [null, Validators.required],
      urlCapa: [null, Validators.required],
    });
  }

  obter() {
    this.livroService.obter().subscribe((res) => (this.livros = res));
  }
  obterAutores() {
    this.autorService.obter().subscribe((res) => (this.autores = res));
  }

  obterGeneros() {
    this.generoService.obter().subscribe((res) => (this.generos = res));
  }

  submit() {
    if (this.form.valid) {
      this.submitted = false;
      this.salvar();
    }

    this.submitted = true;
  }

  salvar() {r
    const model = this.form.getRawValue();
    model.generoId = Number(model.generoId);
    model.autorId = Number(model.autorId);
    const request = this.livroId
      ? this.livroService.alterar(this.livroId, model)
      : this.livroService.criar(model);

    request.subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  alterarSituacao(livro) {
    const ativo = livro.ativo ? false : true;
    this.livroService.inativarAtivar(livro.livroId, ativo).subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  abrirModal(livro?: any) {
    this.form.reset();

    if (livro) {
      const { livroId } = livro;

      this.livroId = livroId;
      this.form.patchValue({
        ...livro
      });

      this.editar = true;
    } else {
      this.livroId = '';
      this.editar = false;
      this.form.reset();
    }

    this.modal.show();
  }

  fecharModal() {
    this.form.reset();
    this.modal.hide();
  }
}
