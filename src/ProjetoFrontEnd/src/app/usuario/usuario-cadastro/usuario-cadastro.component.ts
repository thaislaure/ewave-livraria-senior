import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { InstituicaoService } from "src/app/instituicao/instituicao.service";
import { UsuarioService } from "../usuario.service";

@Component({
  selector: "app-usuario-cadastro",
  templateUrl: "./usuario-cadastro.component.html",
  styleUrls: ["./usuario-cadastro.component.scss"],
})
export class UsuarioCadastroComponent implements OnInit {
  form: FormGroup;

  instituicoes = [];

  usuarioId: string;

  editar = false;
  submitted = false;

  formEndereco;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private instituicaoService: InstituicaoService
  ) {
    this.construirFormulario();
    this.obterInstituicoes();
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(({ id: usuarioId }) => {
      if (usuarioId) {
        this.usuarioId = usuarioId;
        this.obter(usuarioId);
      } else {
        this.usuarioId = '';
      }
    });

  }

  construirFormulario() {
    this.form = this.formBuilder.group({
      instituicaoId: new FormControl(''),
      nome: new FormControl('', [Validators.required]),
      cpf: new FormControl('', [Validators.required]),
      endereco: new FormControl(''),
      telefone: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      senha: new FormControl('', [Validators.required])

    });
  }

  obter(usuarioId) {
    this.usuarioService.obterPorId(usuarioId).subscribe((res) => {
      this.patchValue(res);
    });
  }

  patchValue(usuario: any) {
    this.form.patchValue(usuario);
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

    model.instituicaoId = Number(model.instituicaoId)

    const request = this.usuarioId
      ? this.usuarioService.alterar(this.usuarioId, model)
      : this.usuarioService.criar(model);

    request.subscribe(() => {
      this.form.reset();
      this.irParaTelaDeConsulta();
    });
  }

  cancelar() {
    this.setFormularioSemAlteracao();
  }

  obterInstituicoes() {
    this.instituicaoService.obter().subscribe((res) => {
      this.instituicoes = res;
    });
  }

  setFormularioSemAlteracao(form?: FormGroup) {
    const formulario = form ?? this.form;
    formulario.markAsPristine();
    formulario.markAsUntouched();
  }

  irParaTelaDeConsulta() {
    this.router.navigate(["usuario"]);
  }
}
