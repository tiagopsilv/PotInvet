USE [master]
GO
/****** Object:  Database [TCCInvest]    Script Date: 09/29/2012 09:33:13 ******/
CREATE DATABASE [TCCInvest] ON  PRIMARY 
( NAME = N'TCCInvest', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\TCCInvest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TCCInvest_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\TCCInvest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TCCInvest] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TCCInvest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TCCInvest] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TCCInvest] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TCCInvest] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TCCInvest] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TCCInvest] SET ARITHABORT OFF
GO
ALTER DATABASE [TCCInvest] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TCCInvest] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TCCInvest] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TCCInvest] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TCCInvest] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TCCInvest] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TCCInvest] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TCCInvest] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TCCInvest] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TCCInvest] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TCCInvest] SET  DISABLE_BROKER
GO
ALTER DATABASE [TCCInvest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TCCInvest] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TCCInvest] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TCCInvest] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TCCInvest] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TCCInvest] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TCCInvest] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TCCInvest] SET  READ_WRITE
GO
ALTER DATABASE [TCCInvest] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TCCInvest] SET  MULTI_USER
GO
ALTER DATABASE [TCCInvest] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TCCInvest] SET DB_CHAINING OFF
GO
USE [TCCInvest]
GO
/****** Object:  Table [dbo].[Projetos]    Script Date: 09/29/2012 09:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projetos](
	[ID_Projeto] [int] NOT NULL,
	[NomeProjeto] [varchar](30) NOT NULL,
	[DescricaoProjeto] [text] NULL,
	[PerfilProjeto] [varchar](15) NULL,
	[RamoAtividade] [varchar](15) NULL,
	[Data] [datetime] NULL,
	[UsuarioCad] [varchar](15) NULL,
	[DtCadastro] [datetime] NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
	[ImagemProjeto] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DDD] [varchar](2) NULL,
	[Telefone] [varchar](50) NULL,
	[Endereco] [varchar](50) NULL,
	[Cidade] [varchar](50) NULL,
	[Estado] [varchar](2) NULL,
	[VideoProjeto] [varchar](5000) NULL,
	[ImgApres] [varchar](50) NULL,
 CONSTRAINT [PK_Projetos] PRIMARY KEY CLUSTERED 
(
	[ID_Projeto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Projetos_ID_Projeto] UNIQUE NONCLUSTERED 
(
	[ID_Projeto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empreendedor]    Script Date: 09/29/2012 09:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empreendedor](
	[ID_Empreendedor] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](15) NOT NULL,
	[WebPage] [varchar](50) NULL,
	[Foto] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DDD] [int] NULL,
	[Telefone] [varchar](15) NULL,
	[DDD_Celular] [int] NULL,
	[Celular] [varchar](15) NULL,
	[DataNascimento] [datetime] NULL,
	[Escolaridade] [varchar](25) NULL,
	[Formacao] [varchar](25) NULL,
	[Endereco] [varchar](60) NULL,
	[Complemento] [varchar](50) NULL,
	[CEP] [varchar](9) NULL,
	[Cidade] [varchar](25) NULL,
	[UF] [varchar](2) NULL,
	[Sexo] [char](1) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
	[Contato] [bit] NULL,
	[Descricao] [varchar](6000) NULL,
	[Linkedin] [varchar](50) NULL,
	[Facebook] [varchar](50) NULL,
	[GooglePlus] [varchar](50) NULL,
	[Skype] [varchar](50) NULL,
	[Twitter] [varchar](50) NULL,
	[Msn] [varchar](50) NULL,
	[Nome] [varchar](60) NOT NULL,
 CONSTRAINT [PK_Empreendedor] PRIMARY KEY CLUSTERED 
(
	[ID_Empreendedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Empreendedor_ID_Empreendedor] UNIQUE NONCLUSTERED 
(
	[ID_Empreendedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 09/29/2012 09:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[login] [varchar](50) NOT NULL,
	[senha] [varchar](5000) NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Investidor]    Script Date: 09/29/2012 09:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Investidor](
	[ID_Investidor] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NULL,
	[CPF] [varchar](14) NOT NULL,
	[WebPage] [varchar](50) NULL,
	[Email] [varchar](30) NULL,
	[DDD] [int] NULL,
	[Telefone] [varchar](15) NULL,
	[DDD_Celular] [int] NULL,
	[Celular] [varchar](15) NULL,
	[DataNascimento] [datetime] NULL,
	[Endereco] [varchar](60) NULL,
	[Complemento] [varchar](50) NULL,
	[CEP] [varchar](9) NULL,
	[Cidade] [varchar](25) NULL,
	[UF] [varchar](2) NULL,
	[Sexo] [char](1) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_Investidor] PRIMARY KEY CLUSTERED 
(
	[ID_Investidor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Investidor_ID_Investidor] UNIQUE NONCLUSTERED 
(
	[ID_Investidor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Mensagens_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Mensagens_Upd]
	@ID_Mensagens int  ,
	@ID_Projeto int,
	@FlagAgenteOuInvestidor int,
	@Texto text = Null,
	@Titulo varchar(50) = Null,
	@Data datetime,
	@Usuario varchar(10)
As

BEGIN TRANSACTION

Update Mensagens Set 	ID_Projeto = @ID_Projeto,
						FlagAgenteOuInvestidor = @FlagAgenteOuInvestidor,
						Texto = @Texto,
						Titulo = @Titulo,
						Data = @Data,
						Usuario = @Usuario,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_Mensagens = @ID_Mensagens
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Mensagens_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Mensagens_Add] 
	@ID_Projeto int,
	@FlagAgenteOuInvestidor int,
	@Texto text = Null,
	@Titulo varchar(50) = Null,
	@Data datetime,
	@Usuario varchar(15) = Null
As

BEGIN TRANSACTION

Insert into Mensagens(ID_Projeto,
						FlagAgenteOuInvestidor,
						Texto,
						Titulo,
						Data,
						Usuario,
						DtCadastro,
						UsuarioCad)
Values (@ID_Projeto,
		@FlagAgenteOuInvestidor,
		@Texto,
		@Titulo,
		@Data,
		@Usuario,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Login_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Login_Sel]
					@login varchar(50) = null
As
SELECT [login]
      ,[senha]
      ,[DtCadastro]
  FROM [TCCInvest].[dbo].[Login]
Where [login] = IsNull([login], @login)
GO
/****** Object:  StoredProcedure [dbo].[sp_Projetos_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Projetos_Add] 
           @NomeProjeto varchar(30) = Null,
           @DescricaoProjeto text = Null,
           @ImagemProjeto varchar(50) = Null,
           @VideoProjeto varchar(50) = Null,
           @PerfilProjeto varchar(15) = Null,
           @RamoAtividade varchar(15) = Null,
           @Usuario varchar(15)
As

BEGIN TRANSACTION

Declare @ID Int

Set @ID = (Select (Max(IsNull(ID_Projeto, 0)) + 1) From Projetos)
    
INSERT INTO [Projetos]
           ([ID_Projeto]
           ,[NomeProjeto]
           ,[DescricaoProjeto]
           ,[ImagemProjeto]
           ,[VideoProjeto]
           ,[PerfilProjeto]
           ,[RamoAtividade]
           ,[Data]
           ,[UsuarioCad]
           ,[DtCadastro])
     VALUES
           (@ID,
           @NomeProjeto,
           @DescricaoProjeto,
           @ImagemProjeto,
           @VideoProjeto,
           @PerfilProjeto,
           @RamoAtividade,
           getdate(),
           @Usuario,
           getdate())

IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select @ID As ID_Projeto From Projetos

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Projetos_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Projetos_Upd]
		@ID_Projeto Int,
		@NomeProjeto varchar(30) = Null,
		@DescricaoProjeto text = Null,
		@ImagemProjeto varchar(50) = Null,
		@VideoProjeto varchar(50) = Null,
		@PerfilProjeto varchar(15) = Null,
		@RamoAtividade varchar(15) = Null,
		@Usuario varchar(15)
As

BEGIN TRANSACTION

Update Projetos Set NomeProjeto = @NomeProjeto,
						DescricaoProjeto = @DescricaoProjeto,
						ImagemProjeto = @ImagemProjeto,
						VideoProjeto = @VideoProjeto,
						PerfilProjeto = @PerfilProjeto,
						RamoAtividade = @RamoAtividade,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_Projeto = @ID_Projeto
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Investidor_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Investidor_Upd]
	@ID_Investidor int  ,
	@Nome varchar(20),
	@CPF varchar(14),
	@WebPage varchar(50) = Null,
	@Email varchar(30) = Null,
	@DDD int = Null,
	@Telefone varchar(15) = Null,
	@DDD_Celular int = Null,
	@Celular varchar(15) = Null,
	@DataNascimento datetime = Null,
	@Escolaridade varchar(25) = Null,
	@Formacao varchar(25) = Null,
	@Endereco varchar(60) = Null,
	@Complemento varchar(50) = Null,
	@CEP varchar(9) = Null,
	@Cidade varchar(25) = Null,
	@UF varchar(2) = Null,
	@Sexo char(1) = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update Investidor Set Nome = @Nome,
						CPF = @CPF,
						WebPage = @WebPage,
						Email = @Email,
						DDD = @DDD,
						Telefone = @Telefone,
						DDD_Celular = @DDD_Celular,
						Celular = @Celular,
						DataNascimento = @DataNascimento,
						Endereco = @Endereco,
						Complemento = @Complemento,
						CEP = @CEP,
						Cidade = @Cidade,
						UF = @UF,
						Sexo = @Sexo,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_Investidor = @ID_Investidor
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Investidor_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Investidor_Sel]
	@ID_Investidor int = Null,
	@CPF varchar(14) = Null
As

SELECT [ID_Investidor]
      ,[Nome]
      ,[CPF]
      ,[WebPage]
      ,[Email]
      ,[DDD]
      ,[Telefone]
      ,[DDD_Celular]
      ,[Celular]
      ,[DataNascimento]
      ,[Endereco]
      ,[Complemento]
      ,[CEP]
      ,[Cidade]
      ,[UF]
      ,[Sexo]
      ,[DtCadastro]
      ,[UsuarioCad]
      ,[DtAtualizacao]
      ,[UsuarioAtu]
  FROM [Investidor]
  Where ID_Investidor = IsNull(@ID_Investidor, ID_Investidor) And
        CPF = IsNull(@CPF, CPF)
GO
/****** Object:  StoredProcedure [dbo].[sp_Investidor_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Investidor_Add] 
	@Nome varchar(20),
	@CPF varchar(14),
	@WebPage varchar(50) = Null,
	@Email varchar(30) = Null,
	@DDD int = Null,
	@Telefone varchar(15) = Null,
	@DDD_Celular int = Null,
	@Celular varchar(15) = Null,
	@DataNascimento datetime = Null,
	@Endereco varchar(60) = Null,
	@Complemento varchar(50) = Null,
	@CEP varchar(9) = Null,
	@Cidade varchar(25) = Null,
	@UF varchar(2) = Null,
	@Sexo char(1) = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Insert into Investidor(Nome,
						CPF,
						WebPage,
						Email,
						DDD,
						Telefone,
						DDD_Celular,
						Celular,
						DataNascimento,
						Endereco,
						Complemento,
						CEP,
						Cidade,
						UF,
						Sexo,
						DtCadastro,
						UsuarioCad)
Values (@Nome,
		@CPF,
		@WebPage,
		@Email,
		@DDD,
		@Telefone,
		@DDD_Celular,
		@Celular,
		@DataNascimento,
		@Endereco,
		@Complemento,
		@CEP,
		@Cidade,
		@UF,
		@Sexo,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Investidor) as ID_Investidor from Investidor

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Empreendedor_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Empreendedor_Upd]
	@ID_Empreendedor int  ,
	@CPF varchar(15),
	@Nome varchar(20),
	@WebPage varchar(50) = Null,
	@Foto varchar(50) = Null,
	@Email varchar(50) = Null,
	@DDD int = Null,
	@Telefone varchar(15) = Null,
	@DDD_Celular int = Null,
	@Celular varchar(15) = Null,
	@DataNascimento datetime = Null,
	@Escolaridade varchar(25) = Null,
	@Formacao varchar(25) = Null,
	@Endereco varchar(60) = Null,
	@Complemento varchar(50) = Null,
	@CEP varchar(9) = Null,
	@Cidade varchar(25) = Null,
	@UF varchar(2) = Null,
	@Sexo char(1) = Null,
	@Usuario varchar(15)
As
BEGIN TRANSACTION

Update Empreendedor Set CPF = @CPF,
						Nome = @Nome,
						WebPage = @WebPage,
						Foto = @Foto,
						Email = @Email,
						DDD = @DDD,
						Telefone = @Telefone,
						DDD_Celular = @DDD_Celular,
						Celular = @Celular,
						DataNascimento = @DataNascimento,
						Escolaridade = @Escolaridade,
						Formacao = @Formacao,
						Endereco = @Endereco,
						Complemento = @Complemento,
						CEP = @CEP,
						Cidade = @Cidade,
						UF = @UF,
						Sexo = @Sexo,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_Empreendedor = @ID_Empreendedor
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Empreendedor_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Empreendedor_Sel]
	@ID_Empreendedor int = Null
As

SELECT E.[ID_Empreendedor]
      ,E.[CPF]
      ,E.[Nome]
      ,E.[WebPage]
      ,E.[Foto]
      ,E.[Email]
      ,E.[DDD]
      ,E.[Telefone]
      ,E.[DDD_Celular]
      ,E.[Celular]
      ,E.[DataNascimento]
      ,E.[Escolaridade]
      ,E.[Formacao]
      ,E.[Endereco]
      ,E.[Complemento]
      ,E.[CEP]
      ,E.[Cidade]
      ,E.[UF]
      ,E.[Sexo]
      ,E.[DtCadastro]
      ,E.[UsuarioCad]
      ,E.[DtAtualizacao]
      ,E.[UsuarioAtu]
      ,E.[Contato]
      ,E.[Descricao]
      ,E.[Linkedin]
      ,E.[Facebook]
      ,E.[GooglePlus]
      ,E.[Skype]
      ,E.[Twitter]
      ,E.[Msn]
  FROM [Empreendedor] E 
Where ID_Empreendedor = IsNull(@ID_Empreendedor, ID_Empreendedor)
GO
/****** Object:  StoredProcedure [dbo].[sp_Empreendedor_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Empreendedor_Add] 
	@CPF varchar(15),
	@Nome varchar(20),
	@WebPage varchar(50) = Null,
	@Foto varchar(50) = Null,
	@Email varchar(50) = Null,
	@DDD int = Null,
	@Telefone varchar(15) = Null,
	@DDD_Celular int = Null,
	@Celular varchar(15) = Null,
	@DataNascimento datetime = Null,
	@Escolaridade varchar(25) = Null,
	@Formacao varchar(25) = Null,
	@Endereco varchar(60) = Null,
	@Complemento varchar(50) = Null,
	@CEP varchar(9) = Null,
	@Cidade varchar(25) = Null,
	@UF varchar(2) = Null,
	@Sexo char(1) = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Insert into Empreendedor(CPF,
						Nome,
						WebPage,
						Foto,
						Email,
						DDD,
						Telefone,
						DDD_Celular,
						Celular,
						DataNascimento,
						Escolaridade,
						Formacao,
						Endereco,
						Complemento,
						CEP,
						Cidade,
						UF,
						Sexo,
						DtCadastro,
						UsuarioCad)
Values (@CPF,
		@Nome,
		@WebPage,
		@Foto,
		@Email,
		@DDD,
		@Telefone,
		@DDD_Celular,
		@Celular,
		@DataNascimento,
		@Escolaridade,
		@Formacao,
		@Endereco,
		@Complemento,
		@CEP,
		@Cidade,
		@UF,
		@Sexo,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Empreendedor) as ID_Empreendedor from Empreendedor

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  Table [dbo].[GrupoProjeto]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoProjeto](
	[ID_GrupoProjetos] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projetos] [int] NOT NULL,
	[ID_Emprededor] [int] NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_GrupoProjeto] PRIMARY KEY CLUSTERED 
(
	[ID_GrupoProjetos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_GrupoProjeto_ID_GrupoProjetos] UNIQUE NONCLUSTERED 
(
	[ID_GrupoProjetos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Documentos]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Documentos](
	[ID_Documento] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[EnderecoDocumento] [varchar](50) NOT NULL,
	[Titulo] [varchar](15) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
	[Tipo] [varchar](15) NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[ID_Documento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Documentos_ID_Documento] UNIQUE NONCLUSTERED 
(
	[ID_Documento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustoProjeto]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustoProjeto](
	[ID_Custo] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Descricao] [varchar](50) NULL,
	[CustoEstimado] [decimal](10, 2) NULL,
	[Justificativa] [varchar](50) NULL,
	[Data] [datetime] NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_CustoProjeto] PRIMARY KEY CLUSTERED 
(
	[ID_Custo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_CustoProjeto_ID_Custo] UNIQUE NONCLUSTERED 
(
	[ID_Custo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Calendario]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calendario](
	[ID_Calendario] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Hora] [datetime] NOT NULL,
	[Descricao] [varchar](50) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_Calendario] PRIMARY KEY CLUSTERED 
(
	[ID_Calendario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Calendario_ID_Calendario] UNIQUE NONCLUSTERED 
(
	[ID_Calendario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Agentes]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Agentes](
	[ID_Agente] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Nome] [varchar](50) NULL,
	[CPF] [varchar](14) NULL,
	[CNPJ] [varchar](22) NULL,
	[Email] [varchar](50) NULL,
	[DDD] [int] NULL,
	[Telefone] [varchar](15) NULL,
	[DDD_Celular] [int] NULL,
	[Celular] [varchar](15) NULL,
	[DataNascimento] [datetime] NULL,
	[Endereco] [varchar](60) NULL,
	[Complemento] [varchar](50) NULL,
	[CEP] [varchar](9) NULL,
	[Cidade] [varchar](25) NULL,
	[UF] [varchar](2) NULL,
	[Sexo] [char](1) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_Agentes] PRIMARY KEY CLUSTERED 
(
	[ID_Agente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Agentes_ID_Agente] UNIQUE NONCLUSTERED 
(
	[ID_Agente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MensagensProjeto]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MensagensProjeto](
	[ID_Mensagens] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Texto] [text] NULL,
	[Titulo] [varchar](50) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_Mensagens] PRIMARY KEY CLUSTERED 
(
	[ID_Mensagens] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Mensagens_ID_Mensagens] UNIQUE NONCLUSTERED 
(
	[ID_Mensagens] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MensagensInvestidor]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[MensagensInvestidor](
	[ID_Mensagens] [int] IDENTITY(1,1) NOT NULL,
	[ID_Investidor] [int] NOT NULL,
	[Texto] [text] NULL,
	[Titulo] [varchar](50) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_MensagensInvestidor] PRIMARY KEY CLUSTERED 
(
	[ID_Mensagens] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ranking]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ranking](
	[ID_Ranking] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projetos] [int] NOT NULL,
	[ID_Investidor] [int] NOT NULL,
	[Nota] [int] NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[ID_Ranking] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Ranking_ID_Ranking] UNIQUE NONCLUSTERED 
(
	[ID_Ranking] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjetosVisitados]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ProjetosVisitados](
	[ID_ProjetosVisitados] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[ID_Investidor] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Hora] [datetime] NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_ProjetosVisitados] PRIMARY KEY CLUSTERED 
(
	[ID_ProjetosVisitados] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_ProjetosVisitados_ID_ProjetosVisitados] UNIQUE NONCLUSTERED 
(
	[ID_ProjetosVisitados] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjetosInvestidos]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjetosInvestidos](
	[ID_ProjetoInvestidos] [int] IDENTITY(1,1) NOT NULL,
	[ID_Investidor] [int] NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
	[Valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ProjetosInvestidos] PRIMARY KEY CLUSTERED 
(
	[ID_ProjetoInvestidos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LucroProjeto]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LucroProjeto](
	[ID_Lucro] [int] IDENTITY(1,1) NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Descricao] [varchar](50) NULL,
	[ValorEstimado] [decimal](10, 2) NULL,
	[Justificativa] [varchar](50) NULL,
	[Data] [datetime] NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_LucroProjeto] PRIMARY KEY CLUSTERED 
(
	[ID_Lucro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_LucroProjeto_ID_Lucro] UNIQUE NONCLUSTERED 
(
	[ID_Lucro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_Investidor](
	[ID_Investidor] [int] NOT NULL,
	[login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login_Investidor] PRIMARY KEY CLUSTERED 
(
	[ID_Investidor] ASC,
	[login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login_Agente]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_Agente](
	[ID_Agente] [int] NOT NULL,
	[login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login_Agente] PRIMARY KEY CLUSTERED 
(
	[ID_Agente] ASC,
	[login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MensagensAgente]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[MensagensAgente](
	[ID_Mensagens] [int] IDENTITY(1,1) NOT NULL,
	[ID_Agente] [int] NOT NULL,
	[Texto] [text] NULL,
	[Titulo] [varchar](50) NULL,
	[DtCadastro] [datetime] NOT NULL,
	[UsuarioCad] [varchar](15) NOT NULL,
	[DtAtualizacao] [datetime] NULL,
	[UsuarioAtu] [varchar](15) NULL,
 CONSTRAINT [PK_MensagensAgente] PRIMARY KEY CLUSTERED 
(
	[ID_Mensagens] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Documento_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Documento_Upd]
						@ID_Documento int
						,@ID_Projeto int
						,@EnderecoDocumento varchar(50)
						,@Titulo varchar(15)
						,@Tipo varchar(15)
						,@Usuario varchar(15)
As

BEGIN TRANSACTION

UPDATE [TCCInvest].[dbo].[Documentos]
   SET [ID_Projeto] = @ID_Projeto
      ,[EnderecoDocumento] = @EnderecoDocumento
      ,[Titulo] = @Titulo
      ,[DtAtualizacao] = getdate()
      ,[UsuarioAtu] = @Usuario
      ,[Tipo] = @Tipo
 WHERE ID_Documento = @ID_Documento
 
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Documento_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Documento_Sel]
	@ID_Documento int = Null,
	@ID_Projeto Int = Null
As

SELECT [ID_Documento]
      ,[ID_Projeto]
      ,[EnderecoDocumento]
      ,[Titulo]
      ,[Tipo]
  FROM [Documentos]
Where ID_Documento = IsNull(@ID_Documento, ID_Documento) And ID_Projeto = IsNull(@ID_Projeto, ID_Projeto)

IF @@ERROR <> 0 GOTO TrataErro

Return 0

TrataErro:
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Documento_Del]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Documento_Del]
	@ID_Documento int
As

DELETE FROM [TCCInvest].[dbo].[Documentos]
      WHERE ID_Documento = @ID_Documento
GO
/****** Object:  StoredProcedure [dbo].[sp_Documento_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Documento_Add] @ID_Projeto int
										,@EnderecoDocumento varchar(50)
										,@Titulo varchar(15)
										,@Tipo varchar(15)
										,@Usuario varchar(15)
As

BEGIN TRANSACTION

INSERT INTO [Documentos]
           ([ID_Projeto]
           ,[EnderecoDocumento]
           ,[Titulo]
           ,[DtCadastro]
           ,[UsuarioCad]
           ,[Tipo])
     VALUES
           (@ID_Projeto
           ,@EnderecoDocumento
           ,@Titulo
           ,getdate()
           ,@Usuario
           ,@Tipo)
           
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Documento) From [Documentos]

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_CustoProjeto_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_CustoProjeto_Upd]
	@ID_Custo int  ,
	@ID_Projeto int,
	@Descricao varchar(50) = Null,
	@CustoEstimado decimal(10,2) = Null,
	@Justificativa varchar(50) = Null,
	@Data datetime = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update CustoProjeto Set ID_Projeto = @ID_Projeto,
					Descricao = @Descricao,
					CustoEstimado = @CustoEstimado,
					Justificativa = @Justificativa,
					Data = @Data,
					DtAtualizacao = getdate(),
					UsuarioAtu = @Usuario
Where ID_Custo = @ID_Custo
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_CustoProjeto_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_CustoProjeto_Sel]
	@ID_Custo int = Null,
	@ID_Projeto int = Null
As

SELECT [ID_Custo]
      ,[ID_Projeto]
      ,[Descricao]
      ,[CustoEstimado]
      ,[Justificativa]
      ,[Data]
  FROM [CustoProjeto]
Where ID_Custo = IsNull(@ID_Custo, ID_Custo) And ID_Projeto = IsNull(@ID_Projeto, ID_Projeto)
Order By [Data]
GO
/****** Object:  StoredProcedure [dbo].[sp_CustoProjeto_Del]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_CustoProjeto_Del]
	@ID_Custo int = Null
As

DELETE FROM [CustoProjeto]
Where ID_Custo = IsNull(@ID_Custo, ID_Custo)
GO
/****** Object:  StoredProcedure [dbo].[sp_CustoProjeto_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_CustoProjeto_Add] 
	@ID_Projeto int,
	@Descricao varchar(50) = Null,
	@CustoEstimado decimal(10,2) = Null,
	@Justificativa varchar(50) = Null,
	@Data datetime = Null,
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

Insert into CustoProjeto(ID_Projeto,
						Descricao,
						CustoEstimado,
						Justificativa,
						Data,
						DtCadastro,
						UsuarioCad)
Values (@ID_Projeto,
		@Descricao,
		@CustoEstimado,
		@Justificativa,
		@Data,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Custo) as CustoProjeto from CustoProjeto

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Agentes_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Agentes_Upd]
	@ID_Agente int,
	@ID_Projeto int,
	@Nome varchar(50) = Null,
	@CPF varchar(14) = Null,
	@CNPJ varchar(22) = Null,
	@Email varchar(50) = NULL,
	@DDD int = NULL,
	@Telefone varchar(15) = null,
	@DDD_Celular int = null,
	@Celular varchar(15) = null,
	@DataNascimento datetime = null,
	@Endereco varchar(60) = null,
	@Complemento varchar(50) = null,
	@CEP varchar(9) = null,
	@Cidade varchar(25) = null,
	@UF varchar(2) = null,
	@Sexo char(1) = null,
	@Usuario varchar(15)
As
BEGIN TRANSACTION

Update Agentes Set ID_Projeto = @ID_Projeto, 
					Nome = @Nome, 
					CPF = @CPF, 
					CNPJ = @CNPJ, 
					Email = @Email, 
					DDD = @DDD, 
					Telefone = @Telefone, 
					DDD_Celular = @DDD_Celular, 
					Celular = @Celular, 
					DataNascimento = @DataNascimento,
					Endereco = @Endereco, 
					Complemento = @Complemento, 
					CEP = @CEP, 
					Cidade = @Cidade, 
					UF = @UF, 
					Sexo = @Sexo,
					DtAtualizacao = getdate(),
					UsuarioAtu = @Usuario
Where ID_Agente = @ID_Agente
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Agentes_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Agentes_Sel]
	@ID_Agente int
As

SELECT [ID_Agente]
      ,[ID_Projeto]
      ,[Nome]
      ,[CPF]
      ,[CNPJ]
      ,[Email]
      ,[DDD]
      ,[Telefone]
      ,[DDD_Celular]
      ,[Celular]
      ,[DataNascimento]
      ,[Endereco]
      ,[Complemento]
      ,[CEP]
      ,[Cidade]
      ,[UF]
      ,[Sexo]
      ,[DtCadastro]
      ,[UsuarioCad]
      ,[DtAtualizacao]
      ,[UsuarioAtu]
  FROM [Agentes]
Where ID_Agente = @ID_Agente
						 		
IF @@ERROR <> 0 GOTO TrataErro

Return 0

TrataErro:
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Agentes_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Agentes_Add] 
						@Nome varchar(50) = Null,
						@CPF varchar(14) = Null,
						@CNPJ varchar(22) = Null,
						@Email varchar(50) = NULL,
						@DDD int = NULL,
						@Telefone varchar(15) = null,
						@DDD_Celular int = null,
						@Celular varchar(15) = null,
						@DataNascimento datetime = null,
						@Endereco varchar(60) = null,
						@Complemento varchar(50) = null,
						@CEP varchar(9) = null,
						@Cidade varchar(25) = null,
						@UF varchar(2) = null,
						@Sexo char(1) = null,
						@Usuario varchar(15)
As

BEGIN TRANSACTION
    
INSERT INTO [Agentes]
           (Nome,
			CPF,
			CNPJ,
			Email,
			DDD,
			Telefone,
			DDD_Celular,
			Celular,
			DataNascimento,
			Endereco,
			Complemento,
			CEP,
			Cidade,
			UF,
			Sexo,
			UsuarioCad,
			DtCadastro)
     VALUES
			(@Nome,
			@CPF,
			@CNPJ,
			@Email,
			@DDD,
			@Telefone,
			@DDD_Celular,
			@Celular,
			@DataNascimento,
			@Endereco,
			@Complemento,
			@CEP,
			@Cidade,
			@UF,
			@Sexo,
			@Usuario,
           getdate())

IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Agente) as ID_Agente from Agentes

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_GrupoProjeto_Upd]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_GrupoProjeto_Upd]
	@ID_GrupoProjetos int  ,
	@ID_Projetos int,
	@ID_Emprededor int,
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

Update GrupoProjeto Set ID_Projetos = @ID_Projetos,
						ID_Emprededor = @ID_Emprededor,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_GrupoProjetos = @ID_GrupoProjetos
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_GrupoProjeto_Sel]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_GrupoProjeto_Sel] 
    @ID_GrupoProjetos int = Null,
	@ID_Projeto int = Null,
	@ID_Emprededor int = Null
As

SELECT [ID_GrupoProjetos]
      ,[ID_Projetos]
      ,[ID_Emprededor]
  FROM [GrupoProjeto]
Where ID_GrupoProjetos = IsNull(@ID_GrupoProjetos, ID_GrupoProjetos) And ID_Projetos = IsNull(@ID_Projeto, ID_Projetos) And ID_Emprededor = IsNull(ID_Emprededor, @ID_Emprededor)
GO
/****** Object:  StoredProcedure [dbo].[sp_GrupoProjeto_Add]    Script Date: 09/29/2012 09:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_GrupoProjeto_Add] 
	@ID_Projeto int,
	@ID_Emprededor int,
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

Insert into GrupoProjeto(ID_Projetos,
						ID_Emprededor,
						DtCadastro,
						UsuarioCad)
Values (@ID_Projeto,
		@ID_Emprededor,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_GrupoProjetos) From GrupoProjeto

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_LucroProjeto_Upd]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_LucroProjeto_Upd]
	@ID_Lucro int  ,
	@ID_Projeto int,
	@Descricao varchar(50) = Null,
	@ValorEstimado decimal(10,2) = Null,
	@Justificativa varchar(50) = Null,
	@Data datetime = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update LucroProjeto Set ID_Projeto = @ID_Projeto,
						Descricao = @Descricao,
						ValorEstimado = @ValorEstimado,
						Justificativa = @Justificativa,
						Data = @Data,
						DtAtualizacao = getdate(),
						UsuarioAtu = @Usuario
Where ID_Lucro = @ID_Lucro
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_LucroProjeto_Sel]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_LucroProjeto_Sel]
	@ID_Lucro int = Null,
	@ID_Projeto int = Null
As

SELECT [ID_Lucro]
      ,[ID_Projeto]
      ,[Descricao]
      ,[ValorEstimado]
      ,[Justificativa]
      ,[Data]
  FROM [LucroProjeto]
Where ID_Lucro = IsNull(@ID_Lucro, ID_Lucro) And ID_Projeto = IsNull(@ID_Projeto, ID_Projeto)
Order By Data
GO
/****** Object:  StoredProcedure [dbo].[sp_LucroProjeto_Del]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_LucroProjeto_Del]
	@ID_Lucro int = Null
As

DELETE FROM [LucroProjeto]
Where ID_Lucro = IsNull(@ID_Lucro, ID_Lucro)
GO
/****** Object:  StoredProcedure [dbo].[sp_LucroProjeto_Add]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_LucroProjeto_Add] 
	@ID_Projeto int,
	@Descricao varchar(50) = Null,
	@ValorEstimado decimal(10,2) = Null,
	@Justificativa varchar(50) = Null,
	@Data datetime = Null,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Insert into LucroProjeto(ID_Projeto,
						Descricao,
						ValorEstimado,
						Justificativa,
						Data,
						DtCadastro,
						UsuarioCad)
Values (@ID_Projeto,
		@Descricao,
		@ValorEstimado,
		@Justificativa,
		@Data,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_Lucro) as LucroProjeto from LucroProjeto

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Ranking_Upd]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Ranking_Upd]
	@ID_Ranking int  ,
	@ID_Projetos int,
	@ID_Investidor int,
	@Nota int,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update Ranking Set 	ID_Projetos = @ID_Projetos,
					ID_Investidor = @ID_Investidor,
					Nota = @Nota, 
					DtAtualizacao = getdate(),
					UsuarioAtu = @Usuario
Where ID_Ranking = @ID_Ranking
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Ranking_Add]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Ranking_Add] 
	@ID_Projetos int,
	@ID_Investidor int,
	@Nota int,
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

IF (Select Count(1) From Ranking Where ID_Projetos = @ID_Projetos And ID_Investidor = @ID_Investidor) <= 0
	Begin
	Insert into Ranking(ID_Projetos,
						ID_Investidor,
						Nota,
						DtCadastro,
						UsuarioCad)
	Values (@ID_Projetos,
			@ID_Investidor,
			@Nota,
			getdate(),
			@Usuario)
			
	IF @@ERROR <> 0 GOTO TrataErro

	End 
Else
	Begin
	
	Update Ranking Set 	Nota = @Nota, 
					DtAtualizacao = getdate(),
					UsuarioAtu = @Usuario
	Where ID_Projetos = @ID_Projetos And ID_Investidor = @ID_Investidor
							 		
	IF @@ERROR <> 0 GOTO TrataErro
	
	End

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosVisitados_Upd]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ProjetosVisitados_Upd]
	@ID_ProjetosVisitados int  ,
	@ID_Projeto int,
	@ID_Investidor int,
	@Data datetime,
	@Hora datetime,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update ProjetosVisitados Set @ID_Projeto = @ID_Projeto,
							ID_Investidor = @ID_Investidor,
							Data = @Data,
							Hora = @Hora,
							DtAtualizacao = getdate(),
							UsuarioAtu = @Usuario
Where ID_ProjetosVisitados = @ID_ProjetosVisitados
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosVisitados_Sel]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ProjetosVisitados_Sel]
	@ID_ProjetosVisitados int = null,
	@ID_Investidor int = null,
	@ID_Projeto int = null
As

SELECT V.[ID_ProjetosVisitados]
      ,V.[ID_Projeto]
      ,V.[ID_Investidor]
      ,V.[Data]
      ,V.[Hora]
      ,P.NomeProjeto
  FROM [ProjetosVisitados] V Inner Join Projetos P On
	V.[ID_Projeto] = P.[ID_Projeto]
Where ID_ProjetosVisitados = IsNull(@ID_ProjetosVisitados, ID_ProjetosVisitados) And 
V.ID_Investidor = IsNull(@ID_Investidor, V.ID_Investidor) And V.ID_Projeto = IsNull(@ID_Projeto, V.ID_Projeto)
Order By [Data] Desc
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosVisitados_Add]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ProjetosVisitados_Add] 
	@ID_Projeto int,
	@ID_Investidor int,
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

Insert into ProjetosVisitados(ID_Projeto,
							ID_Investidor,
							Data,
							Hora,
							DtCadastro,
							UsuarioCad)
Values (@ID_Projeto,
		@ID_Investidor,
		getdate(),
		getdate(),
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_ProjetosVisitados) From ProjetosVisitados

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosInvestidos_Upd]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ProjetosInvestidos_Upd]
	@ID_ProjetoInvestidos int  ,
	@ID_Investidor int,
	@ID_Projeto int,
	@Usuario varchar(15)
As

BEGIN TRANSACTION

Update ProjetosInvestidos Set ID_Investidor = @ID_Investidor,
							ID_Projeto = @ID_Projeto,
							DtAtualizacao = getdate(),
							UsuarioAtu = @Usuario
Where ID_ProjetoInvestidos = @ID_ProjetoInvestidos
						 		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosInvestidos_Sel]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ProjetosInvestidos_Sel] 
	@ID_ProjetoInvestidos int = Null,
	@ID_Investidor int = Null,
	@ID_Projeto int = Null
As

SELECT [ID_ProjetoInvestidos]
      ,[ID_Investidor]
      ,[ID_Projeto]
      ,[Valor]
  FROM [ProjetosInvestidos]
Where ID_ProjetoInvestidos = IsNull(@ID_ProjetoInvestidos, ID_ProjetoInvestidos) And
ID_Investidor = IsNull(@ID_Investidor, ID_Investidor) And
ID_Projeto = IsNull(@ID_Projeto, ID_Projeto)
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjetosInvestidos_Add]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ProjetosInvestidos_Add] 
	@ID_Investidor int,
	@ID_Projeto int,
	@Valor Decimal(18,2),
	@Usuario Varchar(15)
As

BEGIN TRANSACTION

Insert into ProjetosInvestidos(ID_Investidor,
							ID_Projeto,
							Valor,
							DtCadastro,
							UsuarioCad)
Values (@ID_Investidor,
		@ID_Projeto,
		@Valor,
		getdate(),
		@Usuario)
		
IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Select Max(ID_ProjetoInvestidos) As ID_ProjetoInvestidos From ProjetosInvestidos

Return 0

TrataErro:
Rollback transaction
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Projetos_Sel]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Projetos_Sel]
	@ID_Projeto int = Null,
	@PerfilProjeto varchar(15) = Null,
	@Industria Bit = 0,
	@Varejo Bit = 0,
	@Artistico Bit = 0,
	@TI Bit = 0,
	@Pw Bit = 0,
	@Video Bit = 0,
	@Audio Bit = 0,
	@_Where Varchar(50) = Null
As

BEGIN TRANSACTION

Create Table #Temp_RamoAtividade(Tipo Varchar(15))

If @Industria = 1
	Begin
	
	Insert into #Temp_RamoAtividade(Tipo) Values('Industria') 
	
	End
Else
	Begin
	
	If @Varejo = 1
		Begin
		
		Insert into #Temp_RamoAtividade(Tipo) Values('Varejo') 
		
		End
	Else
	
		if @Artistico = 1
			Begin
			
			Insert into #Temp_RamoAtividade(Tipo) Values('Artistico') 
			
			End
			
		Else
			Begin
			
			If @TI = 1
				Begin
				
				Insert into #Temp_RamoAtividade(Tipo) Values('TI')
				
				End
			
			End
	
	End


SELECT P.ID_Projeto
	  ,P.NomeProjeto
	  ,P.DescricaoProjeto
	  ,P.ImagemProjeto
	  ,P.VideoProjeto
	  ,Case When P.PerfilProjeto Is Null Then
		''
	  Else
		P.PerfilProjeto
	  End As PerfilProjeto
	  ,P.RamoAtividade
	  ,P.Data
	  ,P.Email
	  ,P.DDD
	  ,P.Telefone
	  ,P.Endereco
	  ,P.Cidade
	  ,P.Estado
	  ,P.ImgApres
  INTO #Temp_Projetos
  FROM [Projetos] P
Where P.ID_Projeto = IsNull(@ID_Projeto, P.ID_Projeto) And
      (NomeProjeto Like '%' + IsNull(@_Where, '') + '%' Or
      DescricaoProjeto Like '%' + IsNull(@_Where, '') + '%')
Order by P.Data Desc

If (SELECT Count(Tipo) From #Temp_RamoAtividade) > 0 
	Begin
	Delete #Temp_Projetos Where RamoAtividade Is Null Or RamoAtividade Not In (Select Tipo From #Temp_RamoAtividade)
	End
	

IF @Video = 1
	Begin
	Delete #Temp_Projetos Where VideoProjeto Is Null or Len(LTrim(RTrim(VideoProjeto))) <= 0 
	End
Else
	Begin
	
		IF @PW = 1
			Begin
			Delete #Temp_Projetos Where ID_Projeto Not In (Select ID_Projeto From Documentos Where Tipo = 'PW' And ID_Projeto In (Select ID_Projeto From #Temp_Projetos))
			End
		Else
			Begin
			
			IF @Audio = 1
				Begin
				Delete #Temp_Projetos Where ID_Projeto Not In (Select ID_Projeto From Documentos Where Tipo = 'Au' And ID_Projeto In (Select ID_Projeto From #Temp_Projetos))
				End
			
			End
	End
	
If (Select Count(ID_Projeto) From #Temp_Projetos) > 0
	Begin

	SELECT P.ID_Projeto
		  ,Avg(R.Nota) As Ranking
	  INTO #Temp_Raking
	  FROM Projetos P Inner Join Ranking R On 
	  P.ID_Projeto = R.ID_Projetos
	Where P.ID_Projeto In (Select T.ID_Projeto From #Temp_Projetos T)
	Group By P.ID_Projeto

	SELECT P.ID_Projeto
		  ,Sum(IsNull(C.CustoEstimado,0)) As Custo_Projeto
	  INTO #Temp_Custo_Projeto
	  FROM Projetos P Inner Join CustoProjeto C On 
	  P.ID_Projeto = C.ID_Projeto
	Where P.ID_Projeto In (Select T.ID_Projeto From #Temp_Projetos T)
	Group By P.ID_Projeto

	SELECT P.ID_Projeto
		  ,Sum(IsNull(I.Valor,0)) As Valor_Arrecadado
		  ,((Sum(IsNull(I.Valor,0)) * 100) / Custo_Projeto) As Porcentagem
	  INTO #Temp_Porcentagem
	  FROM Projetos P Inner Join ProjetosInvestidos I On 
	  P.ID_Projeto = I.ID_Projeto 
	  Inner Join #Temp_Custo_Projeto C On
	  P.ID_Projeto = C.ID_Projeto
	Where P.ID_Projeto In (Select T.ID_Projeto From #Temp_Projetos T)
	Group By P.ID_Projeto, C.Custo_Projeto

	SELECT P.ID_Projeto
		  ,P.NomeProjeto
		  ,P.DescricaoProjeto
		  ,P.ImagemProjeto
		  ,P.VideoProjeto
		  ,Case When Len(P.PerfilProjeto) <= 0 Then
			Null
		  Else
			P.PerfilProjeto
		  End As PerfilProjeto
		  ,P.RamoAtividade
		  ,P.Data
		  ,R.Ranking
		  ,C.Custo_Projeto
		  ,V.Valor_Arrecadado
		  ,CONVERT(decimal(6,2), V.Porcentagem) As Porcentagem
		  ,P.Email
		  ,P.DDD
		  ,P.Telefone
		  ,P.Endereco
		  ,P.Cidade
		  ,P.Estado
		  ,P.ImgApres
	  FROM #Temp_Projetos P Left Outer Join #Temp_Raking R On
		P.ID_Projeto = R.ID_Projeto 
		Left Outer Join #Temp_Custo_Projeto C On
		P.ID_Projeto = C.ID_Projeto 
		Left Outer Join #Temp_Porcentagem V On
		P.ID_Projeto = V.ID_Projeto 
	  Where P.PerfilProjeto = IsNull(@PerfilProjeto, P.PerfilProjeto)
	  Order By P.Data Desc

	Drop Table #Temp_Raking 

	Drop Table #Temp_Custo_Projeto

	Drop Table #Temp_Porcentagem

	End

Drop Table #Temp_RamoAtividade
Drop Table #Temp_Projetos

IF @@ERROR <> 0 GOTO TrataErro

COMMIT TRANSACTION

Return 0

TrataErro:
Rollback transaction
Drop Table #Temp_RamoAtividade
Drop Table #Temp_Raking 
Drop Table #Temp_Custo_Projeto
Drop Table #Temp_Porcentagem
Drop Table #Temp_Projetos
RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_Mesagem_Sel]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Mesagem_Sel] 
	@Tipo varchar(10) =	 'Projeto',
    @ID_Mensagem int = Null,
	@ID int = Null
As

IF @Tipo = 'Agente'
	Begin

	SELECT M.[ID_Mensagens]
		  ,M.[ID_Agente] As ID
		  ,M.[Texto]
		  ,M.[Titulo]
		  ,M.[DtCadastro]
		  ,M.[UsuarioCad] As Usuario
	  FROM [MensagensAgente] M
	  Where ID_Mensagens = IsNull(@ID_Mensagem, ID_Mensagens) And M.ID_Agente = IsNull(@ID, M.ID_Agente) 
	End
Else
	Begin
	IF @Tipo = 'Investidor'
		Begin
		SELECT M.[ID_Mensagens]
			  ,M.[ID_Investidor] As ID
			  ,M.[Texto]
			  ,M.[Titulo]
			  ,M.[DtCadastro]
			  ,M.[UsuarioCad] As Usuario
		  FROM [MensagensInvestidor] M 
		  Where ID_Mensagens = IsNull(@ID_Mensagem, ID_Mensagens) And M.ID_Investidor = IsNull(@ID, M.ID_Investidor) 
		End
	else
		Begin
		IF @Tipo = 'Projeto'
			Begin  
			SELECT [ID_Mensagens]
				  ,[ID_Projeto] As ID
				  ,[Texto]
				  ,[Titulo]
				  ,[DtCadastro]
				  ,[UsuarioCad] As Usuario
			  FROM [MensagensProjeto]
			  Where ID_Mensagens = IsNull(@ID_Mensagem, ID_Mensagens) And ID_Projeto = IsNull(@ID, ID_Projeto) 
			End		
		End	
	End
GO
/****** Object:  StoredProcedure [dbo].[sp_Login_Add]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Login_Add]
					@ID int,
					@login varchar(50),
					@senha varchar(5000),
					@Tipo Varchar(50)				
As

IF (Select Count(1) From [Login] Where [login] = @login) > 0
	Begin
	Select 2 As Retorno
	End
Else
	Begin
	
	Insert into [Login]([login], senha) Values(@login, @senha)
	
	IF @Tipo = 'Agente'
		Begin
			Insert into dbo.Login_Agente(ID_Agente, [login]) Values (@ID, @login)
		End
		Else
			Begin
				IF @Tipo = 'Investidor'
				Begin
				Insert into dbo.Login_Investidor(ID_Investidor, [login]) Values (@ID, @login)
				End
			End

		Select 1 As Retorno
			   
	End
GO
/****** Object:  StoredProcedure [dbo].[sp_Login_Valida]    Script Date: 09/29/2012 09:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Login_Valida]
					@login varchar(50),
					@senha varchar(5000)
As

Declare @Tipo Varchar(50)
Declare @ID int

IF (Select Count(login) From [Login] Where [login] = @login And senha = @senha) > 0
	Begin
	IF (Select Count(ID_Agente) From Login_Agente Where [login] = @login) > 0
		Begin
		Set @ID = (Select ID_Agente From Login_Agente Where [login] = @login)
		Set @Tipo = 'Agente'
		End
	Else
		Begin
			IF (Select Count(ID_Investidor) From Login_Investidor Where [login] = @login) > 0
			Begin
			Set @ID = (Select ID_Investidor From Login_Investidor Where [login] = @login)
			Set @Tipo = 'Investidor'
			End
		End

	SELECT @ID As ID,
		   @login As [login],
		   @Tipo As Tipo
		   
	End 
Else
	Begin
	
	SELECT Null As ID,
	   Null As [login],
	   Null As Tipo
	
	End
GO
/****** Object:  Default [DF_Empreendedor_Contato]    Script Date: 09/29/2012 09:33:15 ******/
ALTER TABLE [dbo].[Empreendedor] ADD  CONSTRAINT [DF_Empreendedor_Contato]  DEFAULT ((0)) FOR [Contato]
GO
/****** Object:  Default [DF_Login_DtCadastro]    Script Date: 09/29/2012 09:33:15 ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF_Login_DtCadastro]  DEFAULT (getdate()) FOR [DtCadastro]
GO
/****** Object:  ForeignKey [FK_GrupoProjeto_Empreendedor1]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[GrupoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_GrupoProjeto_Empreendedor1] FOREIGN KEY([ID_Emprededor])
REFERENCES [dbo].[Empreendedor] ([ID_Empreendedor])
GO
ALTER TABLE [dbo].[GrupoProjeto] CHECK CONSTRAINT [FK_GrupoProjeto_Empreendedor1]
GO
/****** Object:  ForeignKey [FK_GrupoProjeto_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[GrupoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_GrupoProjeto_Projetos] FOREIGN KEY([ID_Projetos])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[GrupoProjeto] CHECK CONSTRAINT [FK_GrupoProjeto_Projetos]
GO
/****** Object:  ForeignKey [FK_Documentos_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [FK_Documentos_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [FK_Documentos_Projetos]
GO
/****** Object:  ForeignKey [FK_CustoProjeto_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[CustoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_CustoProjeto_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[CustoProjeto] CHECK CONSTRAINT [FK_CustoProjeto_Projetos]
GO
/****** Object:  ForeignKey [FK_Calendario_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Calendario]  WITH CHECK ADD  CONSTRAINT [FK_Calendario_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[Calendario] CHECK CONSTRAINT [FK_Calendario_Projetos]
GO
/****** Object:  ForeignKey [FK_Agentes_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Agentes]  WITH CHECK ADD  CONSTRAINT [FK_Agentes_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[Agentes] CHECK CONSTRAINT [FK_Agentes_Projetos]
GO
/****** Object:  ForeignKey [FK_MensagensProjeto_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[MensagensProjeto]  WITH CHECK ADD  CONSTRAINT [FK_MensagensProjeto_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[MensagensProjeto] CHECK CONSTRAINT [FK_MensagensProjeto_Projetos]
GO
/****** Object:  ForeignKey [FK_MensagensInvestidor_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[MensagensInvestidor]  WITH CHECK ADD  CONSTRAINT [FK_MensagensInvestidor_Investidor] FOREIGN KEY([ID_Investidor])
REFERENCES [dbo].[Investidor] ([ID_Investidor])
GO
ALTER TABLE [dbo].[MensagensInvestidor] CHECK CONSTRAINT [FK_MensagensInvestidor_Investidor]
GO
/****** Object:  ForeignKey [FK_Ranking_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_Investidor] FOREIGN KEY([ID_Investidor])
REFERENCES [dbo].[Investidor] ([ID_Investidor])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_Investidor]
GO
/****** Object:  ForeignKey [FK_Ranking_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_Projetos] FOREIGN KEY([ID_Projetos])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_Projetos]
GO
/****** Object:  ForeignKey [FK_ProjetosVisitados_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[ProjetosVisitados]  WITH CHECK ADD  CONSTRAINT [FK_ProjetosVisitados_Investidor] FOREIGN KEY([ID_Investidor])
REFERENCES [dbo].[Investidor] ([ID_Investidor])
GO
ALTER TABLE [dbo].[ProjetosVisitados] CHECK CONSTRAINT [FK_ProjetosVisitados_Investidor]
GO
/****** Object:  ForeignKey [FK_ProjetosVisitados_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[ProjetosVisitados]  WITH CHECK ADD  CONSTRAINT [FK_ProjetosVisitados_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[ProjetosVisitados] CHECK CONSTRAINT [FK_ProjetosVisitados_Projetos]
GO
/****** Object:  ForeignKey [FK_ProjetosInvestidos_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[ProjetosInvestidos]  WITH CHECK ADD  CONSTRAINT [FK_ProjetosInvestidos_Investidor] FOREIGN KEY([ID_Investidor])
REFERENCES [dbo].[Investidor] ([ID_Investidor])
GO
ALTER TABLE [dbo].[ProjetosInvestidos] CHECK CONSTRAINT [FK_ProjetosInvestidos_Investidor]
GO
/****** Object:  ForeignKey [FK_ProjetosInvestidos_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[ProjetosInvestidos]  WITH CHECK ADD  CONSTRAINT [FK_ProjetosInvestidos_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[ProjetosInvestidos] CHECK CONSTRAINT [FK_ProjetosInvestidos_Projetos]
GO
/****** Object:  ForeignKey [FK_LucroProjeto_Projetos]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[LucroProjeto]  WITH CHECK ADD  CONSTRAINT [FK_LucroProjeto_Projetos] FOREIGN KEY([ID_Projeto])
REFERENCES [dbo].[Projetos] ([ID_Projeto])
GO
ALTER TABLE [dbo].[LucroProjeto] CHECK CONSTRAINT [FK_LucroProjeto_Projetos]
GO
/****** Object:  ForeignKey [FK_Login_Investidor_Investidor]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Login_Investidor]  WITH CHECK ADD  CONSTRAINT [FK_Login_Investidor_Investidor] FOREIGN KEY([ID_Investidor])
REFERENCES [dbo].[Investidor] ([ID_Investidor])
GO
ALTER TABLE [dbo].[Login_Investidor] CHECK CONSTRAINT [FK_Login_Investidor_Investidor]
GO
/****** Object:  ForeignKey [FK_Login_Investidor_Login]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Login_Investidor]  WITH CHECK ADD  CONSTRAINT [FK_Login_Investidor_Login] FOREIGN KEY([login])
REFERENCES [dbo].[Login] ([login])
GO
ALTER TABLE [dbo].[Login_Investidor] CHECK CONSTRAINT [FK_Login_Investidor_Login]
GO
/****** Object:  ForeignKey [FK_Login_Agente_Agentes]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Login_Agente]  WITH CHECK ADD  CONSTRAINT [FK_Login_Agente_Agentes] FOREIGN KEY([ID_Agente])
REFERENCES [dbo].[Agentes] ([ID_Agente])
GO
ALTER TABLE [dbo].[Login_Agente] CHECK CONSTRAINT [FK_Login_Agente_Agentes]
GO
/****** Object:  ForeignKey [FK_Login_Agente_Login]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[Login_Agente]  WITH CHECK ADD  CONSTRAINT [FK_Login_Agente_Login] FOREIGN KEY([login])
REFERENCES [dbo].[Login] ([login])
GO
ALTER TABLE [dbo].[Login_Agente] CHECK CONSTRAINT [FK_Login_Agente_Login]
GO
/****** Object:  ForeignKey [FK_MensagensAgente_MensagensAgente]    Script Date: 09/29/2012 09:33:30 ******/
ALTER TABLE [dbo].[MensagensAgente]  WITH CHECK ADD  CONSTRAINT [FK_MensagensAgente_MensagensAgente] FOREIGN KEY([ID_Agente])
REFERENCES [dbo].[Agentes] ([ID_Agente])
GO
ALTER TABLE [dbo].[MensagensAgente] CHECK CONSTRAINT [FK_MensagensAgente_MensagensAgente]
GO
