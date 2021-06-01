USE [master]
GO 
CREATE DATABASE [Livraria]    
GO  
USE [Livraria]
GO 
CREATE TABLE [dbo].[Autor](
	[AutorId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](400) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[AutorId] ASC
) 
) 
go
CREATE TABLE [dbo].[Genero](
	[GeneroId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](400) NOT NULL,
 CONSTRAINT [PK_Editora] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC
))
go
CREATE TABLE [dbo].[Instituicao](
	[InstituicaoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Endereco] [varchar](500) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Instituicao] PRIMARY KEY CLUSTERED 
(
	[InstituicaoId] ASC
))
go
CREATE TABLE [dbo].[Livro](
	[LivroId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[GeneroId] [int] NOT NULL,
	[AutorId] [int] NOT NULL,
	[Sinopse] [varchar](500) NULL,
	[UrlCapa] [varchar](1000) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[LivroId] ASC
))
GO
CREATE TABLE [dbo].[LocacaoLivro](
	[LocacaoId] [int] IDENTITY(1,1) NOT NULL,
	[DataLocacao] [datetime] NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[LivroId] [int] NOT NULL,
	[Devolvido] [bit] NOT NULL,
	[DataLiberacao] [datetime] NULL,
	[DataDevolucao] [datetime] NULL,
 CONSTRAINT [PK_Locacao_Livro] PRIMARY KEY CLUSTERED 
(
	[LocacaoId] ASC
))
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](400) NOT NULL,
	[Endereco] [varchar](600) NULL,
	[CPF] [varchar](14) NOT NULL,
	[InstituicaoId] [int] NULL,
	[Telefone] [varchar](20) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Senha] [varchar](10) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
))
GO
ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Autor] FOREIGN KEY([AutorId])
REFERENCES [dbo].[Autor] ([AutorId])
GO
ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Autor]
GO
ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Genero] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Genero] ([GeneroId])
GO
ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Genero]
GO
ALTER TABLE [dbo].[Livro]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Livro] FOREIGN KEY([LivroId])
REFERENCES [dbo].[Livro] ([LivroId])
GO
ALTER TABLE [dbo].[Livro] CHECK CONSTRAINT [FK_Livro_Livro]
GO
ALTER TABLE [dbo].[LocacaoLivro]  WITH CHECK ADD  CONSTRAINT [FK_LocacaoLivro_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[LocacaoLivro] CHECK CONSTRAINT [FK_LocacaoLivro_Usuario]
GO 
