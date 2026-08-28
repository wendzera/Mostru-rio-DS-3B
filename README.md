# Mostruário escolar

Aplicação local em C# e Windows Forms para cadastrar e consultar roupas e
outros produtos. O projeto foi mantido propositalmente simples e comentado para
servir como material de estudo de alunos iniciantes.

## Funcionalidades

- cadastro, pesquisa, alteração e exclusão de produtos;
- cadastro, pesquisa, alteração e exclusão de marcas;
- cadastro, pesquisa, alteração e exclusão de tipos de produto;
- pesquisa parcial sem diferenciar letras maiúsculas e minúsculas;
- validação dos campos antes de gravar;
- validade opcional para produtos;
- proteção contra exclusão de marcas e tipos que estejam em uso.

## Requisitos

- Visual Studio com a carga de trabalho **Desenvolvimento para desktop com .NET**;
- .NET Framework 4.8 Developer Pack;
- PostgreSQL;
- NuGet habilitado para restaurar os pacotes da solução.

## Preparação do banco

1. Crie no PostgreSQL um banco chamado `produto`.
2. Abra o arquivo `database.sql` no pgAdmin ou no `psql`.
3. Execute o script. Ele apaga e recria as tabelas do projeto.
4. Abra `Mostruario/App.config` e localize a conexão `MostruarioDb`.
5. Troque `ALTERE_AQUI` pela senha do usuário PostgreSQL instalado no computador.
6. Se necessário, ajuste também a porta. O exemplo usa a porta `15432`.

> Não envie a senha real do seu computador para o repositório.

## Abrindo o projeto

1. Abra `Mostruario.sln` no Visual Studio.
2. Use **Restaurar Pacotes NuGet** na solução.
3. Compile primeiro em `Debug`.
4. Execute o projeto e teste as telas de Tipos, Marcas e Produtos, nessa ordem.

Tipos e marcas precisam existir antes do cadastro de um produto, pois são
usados nas listas de seleção.

## Organização

- `Model`: classes simples que representam os dados;
- `Controller`: comandos SQL e comunicação com PostgreSQL;
- `View`: formulários e validações de entrada;
- `database.sql`: criação completa das tabelas.

O projeto não utiliza ORM, serviços web ou bibliotecas visuais externas. Os
arquivos `.Designer.cs` são gerados pelo Visual Studio; a lógica escrita pelos
alunos fica nos demais arquivos `.cs`, acompanhada de comentários em português.
