# ewave-livraria-senior
ewave-livraria-senior


Tecnologias implementadas:

Back-end:
- .NET Core 3.1
- ASP.NET MVC Core
- DI nativo do .NET Core
- Dapper
- Test de unidade
- Swagger
- Conteinerização
- SQL
- REST

Front-end:
- Angular 9
- RxJS
- Ngx-bootstrap

Arquitetura:

A arquitetura utilizada foi a três camadas, onde: 

- DAL – Camada de Acesso a dados(Data Access Layer);
- BLL – Camada de Regra de negócios (Business Logic Layer);
- UI – Camada de Apresentação (User Interface);
- Arquitetura completa com preocupações de separação de responsabilidades, SOLID e Código Limpo

Features a serem implementadas

- Iniciei a autenticação com o JWT no back-end, faltou criar tela de login para obter o token, 
armazenar no localstorage e dai nas requisições buscar do localstorage o token e enviar o cabeçalho Authorization.
Dessa forma ter o Usuario logado e fazer as validações e funcionalidade abaixo:

Todo usuario pode emprestar no maximo 2 livros.
Todo emprestimo deve ser no maximo de 30 dias para cada livro.
Informar ao Administrador do Sistema caso um livro extrapole o prazo máximo de dias emprestado.
O Usuário que infringir a regra dos dias fica impossibilitado de emprestar qualquer outro livro até a devolução e só poderá emprestar novamente após 30 dias.
Livros emprestados deverão estar indisponiveis para outros Usuários.
Permitir reservar livros.

---------------------------------------------
Funcionalidades:

-Instituição de Ensino: Permite consultar, criar, alterar e mudar a situação de um cadastro. 

-Usuario: Permite consultar, criar, alterar e mudar a situação de um cadastro.

-Autor: Permite consultar, criar, alterar e excluir. 

-Gênero:Permite consultar, criar, alterar e excluir.

Livro: Permite consultar, criar, alterar e mudar a situação de um cadastro.

Locação de Livro - Permite consultar, criar e devolver um livro

-----------------------------------------------------

Executar o Projeto:

Para executar o projeto, é necessário docker

docker-compose up

Após :

swagger : http://localhost:8080/swagger/index.html

front-end: http://localhost/



