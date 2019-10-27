USE DATA_BASE_NAME;
GO

/***********Endereco***********/
INSERT INTO TaCerto.Endereco (Pais, UF, Cidade, Numero, Complemento, CEP, Logradouro, Bairro)
VALUES
('Brasil', 'SP', 'São Paulo', 217, 'Red Balloon', '05641-900', 'Rua Mal. Hastimphilo de Moura', 'Morumbi');
DECLARE @IdEndereco INT = SCOPE_IDENTITY()

/***********Instituição***********/
INSERT INTO TaCerto.Instituicao (RazaoSocial, NomeFantasia, CNPJ, Email, Telefone, IdEnderecoPrincipal, IdEnderecoCobranca, IsMatriz, IdMatriz)
VALUES
('Red Balloon | Somos Educacao E Participacoes S.a.', 'Red Balloon', '03.824.725/0001-92', 'saopaulo@redballoon.com.br', '(11) 3744-8044', @IdEndereco, @IdEndereco, 1, null);
DECLARE @IdInstituicao INT = SCOPE_IDENTITY()
/***********Pessoa***********/
INSERT INTO TaCerto.Pessoa (IdInstituicao, Perfil, Nome, CPF, Email, Senha)
VALUES
/*admin*/
(@IdInstituicao, 0, 'Evelyn Sousa Pereira', '200.398.121-70', 'evelyn.pereira@redballoon.com.br', '123'),
/*autor*/
(@IdInstituicao, 1, 'Livia Dias Rodrigues', '823.998.438-00', 'livia.rodrigues@redballoon.com.br', '123'),
(@IdInstituicao, 1, 'Mateus Melo Goncalves', '609.796.687-35', 'mateus.goncalves@redballoon.com.br', '123'),
(@IdInstituicao, 1, 'Ana Rodrigues Ferreira', '148.807.090-34', 'ana.ferreira@redballoon.com.br', '123'),
(@IdInstituicao, 1, 'Kauã Barbosa Barros', '580.131.431-80', 'kaua.barros@redballoon.com.br', '123'),
/*aluno*/
(@IdInstituicao, 2, 'Aline Oliveira Fernandes', '535.936.579-02', 'aline.fernandes@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Igor Cavalcanti Silva', '692.774.061-94', 'igor.silva@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Sophia Goncalves Cardoso', '329.307.560-63', 'sophia.cardoso@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Beatrice Lima Sousa', '578.020.776-30', 'beatrice.sousa@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Tiago Alves Silva', '554.707.194-30', 'tiago.silva@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Amanda Melo Barbosa', '109.384.894-45', 'amanda.barbosa@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Breno Melo Barbosa', '918.312.625-25', 'breno.barbosa@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Marina Almeida Silva', '625.791.484-18', 'marina.silva@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Vinícius Martins Melo', '777.566.140-20', 'vinicius.melo@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Marina Pinto Santos', '390.006.345-12', 'marina.santos@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Rebeca Almeida Fernandes', '802.866.959-01', 'rebeca.fernandes@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Laura Almeida Castro', '885.469.562-94', 'laura.castro@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Marcos Silva Cunha', '992.377.589-52', 'marcos.cunha@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Julieta Sousa Gomes', '592.527.323-06', 'julieta.gomes@redballoon.com.br', '123'),
(@IdInstituicao, 2, 'Beatriz Correia Pereira', '461.719.093-78', 'beatriz.pereiraredballoon.com.br', '123');
/*
https://dba.stackexchange.com/questions/130499/insert-into-different-tables-but-same-data
*/