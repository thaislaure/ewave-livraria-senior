import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { InstituicaoService } from "src/app/instituicao/instituicao.service";

@Component({
  selector: "app-instituicao-cadastro",
  templateUrl: "./instituicao-cadastro.component.html",
  styleUrls: ["./instituicao-cadastro.component.scss"],
})
export class InstituicaoCadastroComponent implements OnInit {
  form: FormGroup;

  instituicaoId: string;
  editar = false;
  submitted = false;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private instituicaoService: InstituicaoService
  ) {
    this.construirFormulario();
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(({ instituicaoId: instituicaoId }) => {
      if (instituicaoId) {
        this.instituicaoId = instituicaoId;
        this.obter(instituicaoId);
      }
    });
  }

  construirFormulario() {
    this.form = this.formBuilder.group({
      nome: new FormControl('', [Validators.required]),
      cnpj: new FormControl('', [Validators.required]),
      endereco: new FormControl('', [Validators.required]),
      telefone: new FormControl('', [Validators.required]),
    });
  }

  obter(id) {
    this.instituicaoService.obterPorId(id).subscribe((res) => {
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
    const request = this.instituicaoId
      ? this.instituicaoService.alterar(this.instituicaoId, model)
      : this.instituicaoService.criar(model);

    request.subscribe(() => {
      this.form.reset();
      this.irParaTelaDeConsulta();
    });
  }

  cancelar() {
    this.setFormularioSemAlteracao();
  }

  setFormularioSemAlteracao(form?: FormGroup) {
    const formulario = form ?? this.form;
    formulario.reset();
  }

  irParaTelaDeConsulta() {
    this.router.navigate(["instituicao"]);
  }

}
