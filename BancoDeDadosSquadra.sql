CREATE DATABASE SquadraProdutos
GO

USE SquadraProdutos
GO

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
	Titulo VARCHAR(15) NOT NULL
)
GO

CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Tipo VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(100) NOT NULL UNIQUE,
	Senha VARCHAR(100) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);
GO

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY(1,1),
	IdCategoria INT FOREIGN KEY REFERENCES Categoria(IdCategoria),
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(MAX),
	[Status] VARCHAR(50) NOT NULL,
	Preco DECIMAL(10, 2),
	QuantidadeEstoque INT NOT NULL
)
GO

INSERT INTO TipoUsuario (Titulo) VALUES ('Gerente'), ('Funcionario'), ('Cliente');
GO

INSERT INTO Categoria (Tipo) VALUES ('Alimentação'), ('Higiene'), ('Brinquedos');
GO

INSERT INTO Produto (IdCategoria, Nome, Descricao, [Status], Preco, QuantidadeEstoque) VALUES
(1, 'Royal Canin Gatos','Ração premium para gato 1,5kg', 'Em estoque', 119.99, 25),
(1, 'Royal Canin Cachorros','Ração premium para cachorro 1,5kg', 'Em estoque', 119.99, 25),
(2, 'Sabonete anti pugas', 'Sabonete anti pugas para gatos e cachorros', 'Em estoque', 29.90, 20),
(2, 'Tapete higienico doguito', 'Tapete higienico absorvente', 'Em estoque', 47.90, 25),
(3, 'Toca', 'Toca para gatos em formato de tunel', 'Em estoque', 75.90, 25),
(3, 'Arranhador', 'Arranhador de papelão triangular para gatos', 'Indisponivel', 19.90, 0)
GO

INSERT INTO Usuario (IdTipoUsuario, Email, Senha) VALUES 
(1, 'gerente@gerente.com', 'gerente123'),
(2, 'funcionario@funcionario.com', 'funcionario123'),
(1, 'cliente@cliente.com', 'cliente123')
GO