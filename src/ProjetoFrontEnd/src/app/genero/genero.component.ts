import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

import { ModalDirective } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

import { GeneroService } from "./genero.service";
@Component({
  selector: "app-genero",
  templateUrl: "./genero.component.html",
  styleUrls: ["./genero.component.scss"],
})
export class GeneroComponent implements OnInit {
  @ViewChild("modal") modal: ModalDirective;

  subscription: Subscription;

  form: FormGroup;

  generos = [];
  generoId: string;

  editar = false;
  submitted = false;

  constructor(
    private generoService: GeneroService,
    private formBuilder: FormBuilder,
  ) {
    this.construiFormulario();
  }

  ngOnInit(): void {
    this.obter();
  }

  construiFormulario() {
    this.form = this.formBuilder.group({
      nome: new FormControl('', [Validators.required])
    });
  }

  obter() {
    this.generoService.obter().subscribe((res) => (this.generos = res));
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

    const request = this.generoId
      ? this.generoService.alterar(this.generoId, model)
      : this.generoService.criar(model);

    request.subscribe(() => {
      this.obter();
      this.fecharModal();
    });
  }

  abrirModal(genero?: any) {
    this.form.reset();

    if (genero) {
      const { generoId, nome } = genero;

      this.generoId = generoId;

      this.editar = true;
      this.form.get("nome").setValue(nome);
    } else {
      this.generoId ='';
      this.editar = false;
      this.form.reset();
    }

    this.modal.show();
  }

  fecharModal() {
    this.submitted = false;
    this.form.reset();
    this.modal.hide();
  }


  public deletar(id: string) {
    if (confirm("tem certeza que deseja excluir o cadastro ? ")) {
      this.generoService.excluir(id).subscribe(response => {
        if (response) {
          alert('excluido com sucesso')
          this.obter();
          this.fecharModal();
        } else {
          alert(response.listaErros.join(' \n'))
        }
      })
    }
  }

}
