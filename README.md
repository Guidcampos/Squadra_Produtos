# **Desafio Final - New Thinkers 2024**  
![C#](https://img.shields.io/badge/C%23-.NET-blue)  
![Status](https://img.shields.io/badge/Status-Concluído-green)  

## Sumário  
1. [Descrição do Desafio](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#descri%C3%A7%C3%A3o-do-desafio)
2. [Como rodar o projeto](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#como-rodar-o-projeto)
3. [Banco de Dados](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#banco-de-dados)
4. [Endpoints](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#endpoints)
   - [Auth](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#auth)
   - [Categorias](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#categorias)  
   - [Produtos](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#produtos)
5. [Exemplos de Requisição](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#exemplos-de-requisi%C3%A7%C3%A3o)
6. [Tecnologias Utilizadas](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#6-tecnologias-utilizadas)
7. [Agradecimentos](https://github.com/Guidcampos/Squadra_Produtos/edit/main/README.md#agradecimentos)   

---

## **Descrição do Desafio**  
Desenvolver um **Gerenciador de Produtos** com as seguintes funcionalidades:  

- **Armazenar informações de produtos:**
  - Id, Nome, Descrição, Status, Preço e Quantidade em Estoque.
- **Regras de negócio:**
  - Qualquer pessoa pode consultar produtos.
  - Gerente e Funcionário podem atualizar o estoque.
  - Somente o Gerente pode excluir produtos.

---

## **Como rodar o projeto**  

1. **Clone o repositório:**  
   ```bash
   git clone https://github.com/Guidcampos/Squadra_Produtos.git
   cd Squadra_Produtos
   ```
2. **Abra o projeto no Visual Studio:**  
   Navegue até a pasta `api_ProjetoProdutosSquadra` e abra o arquivo `.sln`.

3. **Configure o Banco de Dados:**  
   - No Visual Studio, acesse a aba **Ferramentas > Conectar-se a um banco de dados**.  
   - Localize o arquivo `Database/ProdutosDatabase.mdf` na pasta do projeto ou utilize o [script SQL](https://github.com/Guidcampos/Squadra_Produtos/blob/main/BancoDeDadosSquadra.sql) para criar o banco manualmente.

4. **Atualize a string de conexão:**  
   - No **SQL Server Object Explorer**, copie a string de conexão do banco criado.  
   - Atualize a chave `"DefaultConnection"` no arquivo `appsettings.json` e a configuração no `ProdutosContext` para refletir a string correta.  

5. **Inicie o servidor:**  
   - No Visual Studio, pressione **F5** ou utilize o comando `dotnet run` no terminal para iniciar o projeto.

---

## **Banco de Dados**  

O projeto utiliza um banco de dados SQL Server com as seguintes tabelas:  
- **Produtos:** Gerencia as informações dos produtos e o estoque.  
- **Categorias:** Armazena categorias para organizar os produtos.  
- **Usuários:** Controla autenticação e permissões de acesso.  

**Script SQL:**  
O script para criação do banco está disponível no repositório:  
- **[Script do banco de dados](https://github.com/Guidcampos/Squadra_Produtos/blob/main/BancoDeDadosSquadra.sql)**  

---

## **Endpoints**

![Auth](https://github.com/user-attachments/assets/d7e21f75-8b40-4274-b895-e36fa517a48a)
![Categorias](https://github.com/user-attachments/assets/9d742c2a-45be-4c10-9d92-64a8257df90b)
![Produtos](https://github.com/user-attachments/assets/92e570d8-7fea-4c2d-8ce9-bd19722a0803)


### **Auth**  
| Método | Endpoint       | Descrição                        |
|--------|----------------|----------------------------------|
| GET    | /auth/listar   | Lista todos os usuários          |
| POST   | /auth/login    | Gera um token para autenticação  |

---

### **Categorias**  
| Método | Endpoint           | Descrição                              |
|--------|--------------------|----------------------------------------|
| GET    | /categorias/listar | Retorna todas as categorias            |
| POST   | /categorias        | Cadastra uma nova categoria            |
| DELETE | /categorias/{id}   | Exclui uma categoria com base no ID    |

---

### **Produtos**  
| Método | Endpoint             | Descrição                                 |
|--------|----------------------|-------------------------------------------|
| GET    | /produtos/listar     | Retorna todos os produtos                |
| GET    | /produtos/estoque    | Retorna produtos disponíveis em estoque  |
| GET    | /produtos/{id}       | Busca um produto pelo ID                 |
| POST   | /produtos            | Cadastra um novo produto                 |
| DELETE | /produtos/{id}       | Exclui um produto pelo ID (Gerente)      |
| PUT    | /produtos/{id}       | Atualiza o estoque de um produto         |

---

## **Exemplos de Requisição**  

### **1. Login (POST /auth/login)**  
**Request Body:**  
```json
{
  "email": "gerente@gerente.com",
  "senha": "gerente123"
}
```

**Response:**

```json

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### **2. Cadastro de Produto (POST /produtos)**
**Request Body:**

```json
{
  "idCategoria": 1,
  "nome": "Royal Canin Gatos",
  "descricao": "Ração premium para gato 1,5kg",
  "preco": 150.00,
  "quantidadeEstoque": 5
}
```
**Response:**

```json
{
  "id": 10,
  "idCategoria": 1,
  "nome": "Royal Canin Gatos",
  "descricao": "Ração premium para gato 1,5kg",
  "preco": 150.00,
  "quantidadeEstoque": 5,
  "status": "Em estoque"
}
```
### 3. **Atualização de Estoque (PUT /produtos/{id})**
**Request Body:**

```json

{
  "quantidadeEstoque": 10
}
```
**Response:**

```json

{
  "id": 10,
  "nome": "Royal Canin Gatos",
  "quantidadeEstoque": 10,
  "status": "Em estoque"
}
```

### **4. Listagem de Produtos (GET /produtos/listar)**

**Response:**


```json
[
  {
    "id": 1,
    "nome": "Royal Canin Gatos",
    "status": "Em estoque",
    "quantidadeEstoque": 10,
    "preco": 150.00
  },
  {
    "id": 2,
    "nome": "Royal Canin Cachorro",
    "status": "Indisponível",
    "quantidadeEstoque": 0,
    "preco": 100.00
  }
]
```

### **5. Exclusão de Produto (DELETE /produtos/{id})**

**Exemplo de URL: /produtos/10**

**Response:**
```json
{
  "message": "Produto deletado com sucesso!"
}
```


### **6. Tecnologias Utilizadas**

- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** SQL Server
- **Autenticação:** JWT
- **Ferramenta de Desenvolvimento:** Visual Studio

### **Agradecimentos**  

Gostaria de expressar minha gratidão

- **New Thinkers 2024:** Pela oportunidade de participar deste desafio e pelo aprendizado adquirido.  
- **Equipe Squadra:** Pelo suporte e colaboração durante o desenvolvimento.  
- **Mentor e Colegas:** Pelas sugestões, feedbacks e pelos ensinamentos.  
 
Este projeto é um reflexo do trabalho feito a partir do bootcamp !  

