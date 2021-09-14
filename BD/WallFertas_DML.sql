USE WallFertas

INSERT INTO TipoUsuarios     (TituloTipoUsuario)
VALUES                      ('Administrador'),
                            ('Cliente');
GO 

INSERT INTO TipoProdutos     (TituloTipoProduto)
VALUES                      ('Arroz'),
							('Feij�o'),
							('A�ucar'),
							('Bebidas'),
							('Ofertas');
							
GO

INSERT INTO Usuarios		(IdTipoUsuario, Nome, Email, Senha)
VALUES                      (1,'Daniel', 'daniel@gmail.com', '123'),
							(2,'Jo�o', 'jo�o@gmail.com', '123')
							
GO

INSERT INTO Produtos		(IdTipoProduto, Nome, Quantidade, Descricao, Imagem, Preco, Validade)
VALUES                      (1,'Arroz Agulhinha', 10, 'Arroz branco', 'arroz.png', 20, '2021-12-31'),
							(2,'feijao Polido', 10, 'fejao preto', 'feijao.png', 25, '2021-12-31'),
							(3,'a�ucar uni�o', 10, 'a�ucar mascavo', 'a�ucar.png', 5, '2021-12-31'),
							(4,'Agua', 10, 'Agua mineral', 'agua.png', 2, '2021-12-31'),
							(5,'Arroz Agulhinha', 10, 'Arroz branco', 'arroz.png', 20, '2021-12-31');
							
GO

INSERT INTO Comentarios		(IdProduto,Descricao)
VALUES                      (1,'Produto de qualidade com pre�o acessivel'),
							(2,'Produto veio com algumas "pedras"'),
							(3,'Estava um pouco doce demais'),
							(4,'Embalagem amassada');
							
							
GO

INSERT INTO Empresas		(Nome,Endereco,CNPJ)
VALUES                      ('WallFertas', 'Alameda Bar�o de Limeira, 539 - Santa Cecilia, S�o Paulo - SP, 01202-001', 864009);
							
GO