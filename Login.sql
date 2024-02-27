INSERT INTO [TCCInvest].[dbo].[Login]
           ([login]
           ,[senha]
           ,[DtCadastro])
     VALUES
           ('Teste1'
           ,'20B8316BC52BF488356C337F538AB64B',>
           ,getdate())
GO

INSERT INTO [TCCInvest].[dbo].[Investidor]
           ([Nome]
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
           ,[UsuarioAtu])
     VALUES
           ('Teste'>
           ,<CPF, varchar(14),>
           ,<WebPage, varchar(50),>
           ,<Email, varchar(30),>
           ,<DDD, int,>
           ,<Telefone, varchar(15),>
           ,<DDD_Celular, int,>
           ,<Celular, varchar(15),>
           ,<DataNascimento, datetime,>
           ,<Endereco, varchar(60),>
           ,<Complemento, varchar(50),>
           ,<CEP, varchar(9),>
           ,<Cidade, varchar(25),>
           ,<UF, varchar(2),>
           ,<Sexo, char(1),>
           ,getdate(),>
           ,'Teste1',>
GO

INSERT INTO [TCCInvest].[dbo].[Login_Investidor]
           ([ID_Investidor]
           ,[login])
     VALUES
           (1,>
           ,Teste1)
GO
