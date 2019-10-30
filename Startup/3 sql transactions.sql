USE DATA_BASE_NAME;
GO

/***********Endereco***********/
INSERT INTO TaCerto.Endereco (Pais, UF, Cidade, Numero, Complemento, CEP, Logradouro, Bairro)
VALUES
('Brasil', 'MS', 'Campo Grande', 0, 'startup', '00000-000', '', '');
DECLARE @IdEndereco INT = SCOPE_IDENTITY()

/***********Instituição***********/
INSERT INTO TaCerto.Instituicao (RazaoSocial, NomeFantasia, CNPJ, Email, Telefone, IdEnderecoPrincipal, IdEnderecoCobranca, IsMatriz, IdMatriz)
VALUES
('startup', 'startup', '03.795.086/0025-51', 'startup@startup.com', '(00) 0000-0000', @IdEndereco, @IdEndereco, 1, null);
DECLARE @IdInstituicao INT = SCOPE_IDENTITY()
/***********Pessoa***********/
INSERT INTO TaCerto.Pessoa (IdInstituicao, Perfil, Nome, CPF, Email, Senha)
VALUES
/*admin*/
(@IdInstituicao, 0, 'admin startup', '000.000.000-00', 'admin@startup.com', '123'),
/*autor*/
(@IdInstituicao, 1, 'professor startup', '000.000.000-00', 'professor@startup.com', '123');