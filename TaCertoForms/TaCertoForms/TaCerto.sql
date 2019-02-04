CREATE TABLE `TaCerto.Jogador` (
	`JogadorId` INT NOT NULL AUTO_INCREMENT,
	`Dinheiro` INT,
	`Experiencia` INT,
	PRIMARY KEY (`JogadorId`)
);


CREATE TABLE `TaCerto.TipoDeFase` (
	`TipoDeFaseId` INT NOT NULL AUTO_INCREMENT,
	`Descricao` TEXT,
	`TipoDeFaseId` INT NOT NULL,
	PRIMARY KEY (`FaseId`)
);

CREATE TABLE `TaCerto.Fase` (
	`FaseId` INT NOT NULL AUTO_INCREMENT,
	`Descricao` TEXT,
	`TipoDeFaseId` INT NOT NULL,
	PRIMARY KEY (`FaseId`)
);

CREATE TABLE `TaCerto.Conquista` (
	`ConquistaId` INT NOT NULL AUTO_INCREMENT,
	`FaseId` INT NOT NULL,
	`Dinheiro` INT,
	`Experiencia` INT,
	PRIMARY KEY (`ConquistaId`)
);
CREATE TABLE `TaCerto.DesafioDeFase` (
	`DesafioDeFaseId` INT NOT NULL AUTO_INCREMENT,
	`FaseId` INT NOT NULL,
	`Significado` VARCHAR(255),
	`Dica` VARCHAR(255),
	PRIMARY KEY (`DesafioDeFaseId`)
);

ALTER TABLE `TaCerto.Conquista` ADD CONSTRAINT `fk_cosquista_fase` FOREIGN KEY (`FaseId`) REFERENCES `TaCerto.Fase` (`FaseId`); 

TaCerto.Fase { FaseId, descricao, tipoDeFase } *
    TaCerto.Conquista { ConquistaId, FaseId, dinheiro, experiencia } *
    TaCerto.DesafioDeFase { DesafioDeFaseId, FaseId, significado, dica } *
        TaCerto.DesafioDeFaseAurelio { DesafioDeFaseAurelioId, DesafioDeFaseId, fraseParaCorrecao, totalSize }
            TaCerto.ConteudoResposta { ConteudoRespostaId, index, palavra }

        TaCerto.DesafioDeFaseExploradorColuna { DesafioDeFaseExploradorColunaId, DesafioDeFaseId, palavra, totalSize }
            TaCerto.Coluna { ColunaId, equivalente, emoji, conteudo }

        TaCerto.DesafioDeFaseExploradorEscolha { DesafioDeFaseExploradorEscolhaId, DesafioDeFaseId, palavra, totalSize }
            TaCerto.PalavraExWrapper { PalavraExWrapperId, equivalente, emoji, conteudo }

        TaCerto.DesafioDeFaseLacuna { DesafioDeFaseLacunaId, DesafioDeFaseId, fraseParaCorrecao, totalSize }
            TaCerto.ConteudoResposta { ConteudoRespostaId, index, palavra }
        
        TaCerto.DesafioDeFaseNormal { DesafioDeFaseNormalId, DesafioDeFaseId, palavra, flag }