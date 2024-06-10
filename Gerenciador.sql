create database estoque;
use estoque;


CREATE TABLE Produto (
ID_Produto INT PRIMARY KEY,
Nome_Produto VARCHAR(10),
ID_setor NVARCHAR(255),
ID_unidade_peso NVARCHAR(50),
ID_Fornecedor INT,
Observacao varchar(40),
Estado TINYINT(1),
FOREIGN KEY (ID_Fornecedor) REFERENCES Fornecedor(ID_Fornecedor)
);

CREATE TABLE MovimentacaoEstoque (
    ID_Movimentacao INT PRIMARY KEY,
    ID_Produto INT,
    TipoMovimentacao NVARCHAR(50),
    QuantidadeMovimentada INT,
    DataMovimentacao DATETIME,
    Observacoes NVARCHAR(255),
    FOREIGN KEY (ID_Produto) REFERENCES Produtos(ID_Produto)
);

CREATE TABLE Fornecedores (
    ID_Fornecedor INT PRIMARY KEY,
    Nome NVARCHAR(100),
    InformacoesContato NVARCHAR(255)
);

CREATE TABLE Clientes (
    ID_Cliente INT PRIMARY KEY,
    Nome NVARCHAR(100),
    Email NVARCHAR(255),
    Telefone NVARCHAR(20),
    Endereco NVARCHAR(255)
);

CREATE TABLE Vendas (
    ID_Venda INT PRIMARY KEY,
    DataVenda DATETIME,
    ID-Produto INT,
    QuantidadeVendida INT,
    PrecoVenda DECIMAL(10, 2),
    ID_Cliente INT,
    FOREIGN KEY (ID_Produto) REFERENCES Produtos(ID_Produto),
    FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente)
);

CREATE TABLE Compras (
    ID_Compra INT PRIMARY KEY,
    DataCompra DATETIME,
    ID_Produto INT,
    QuantidadeComprada INT,
    PrecoCompra DECIMAL(10, 2),
    ID_Fornecedor INT,
    ID_Cliente INT,
    FOREIGN KEY (ID_Produto) REFERENCES Produtos(ID_Produto),
    FOREIGN KEY (ID_Fornecedor) REFERENCES Fornecedores(ID_Fornecedor),
    FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente)
);

