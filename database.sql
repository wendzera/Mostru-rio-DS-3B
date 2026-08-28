-- Este script recria o banco usado pelo projeto escolar.
-- Execute-o dentro do banco "produto" usando o pgAdmin ou o psql.

-- As tabelas são removidas na ordem inversa dos relacionamentos.
DROP TABLE IF EXISTS produto;
DROP TABLE IF EXISTS marca;
DROP TABLE IF EXISTS tipo_produto;

CREATE TABLE tipo_produto (
    codigo SERIAL PRIMARY KEY,
    nome_tipo VARCHAR(40) NOT NULL UNIQUE
);

CREATE TABLE marca (
    codigo SERIAL PRIMARY KEY,
    nome_marca VARCHAR(40) NOT NULL UNIQUE,
    descricao TEXT
);

CREATE TABLE produto (
    codigo SERIAL PRIMARY KEY,
    nome_produto VARCHAR(40) NOT NULL,
    preco_custo NUMERIC(10, 2) NOT NULL CHECK (preco_custo >= 0),
    preco_venda NUMERIC(10, 2) NOT NULL CHECK (preco_venda >= 0),
    quantidade INTEGER NOT NULL CHECK (quantidade >= 0),
    descricao TEXT NOT NULL,
    unidade VARCHAR(10) NOT NULL,
    validade DATE,
    cod_tipo INTEGER NOT NULL,
    cod_marca INTEGER NOT NULL,
    CONSTRAINT fk_produto_tipo FOREIGN KEY (cod_tipo)
        REFERENCES tipo_produto (codigo) ON DELETE RESTRICT,
    CONSTRAINT fk_produto_marca FOREIGN KEY (cod_marca)
        REFERENCES marca (codigo) ON DELETE RESTRICT
);
