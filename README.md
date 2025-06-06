

  

# ClimaConecta API

  

Este projeto consiste numa API RESTful para o **ClimaConecta**, uma plataforma colaborativa que permite o registro, compartilhamento e monitoramento em tempo real de condições climáticas, como enchentes, secas e tempestades.

### Links Complementares

-  **Vídeo Pitch:** https://youtu.be/Vy-Bq_2zqZw

-  **Vídeo Apresentação da Entrega:** https://youtu.be/tjpQUJCfUxw

  

🔗 **Objetivo**: Facilitar a comunicação entre comunidades para alertas rápidos sobre eventos climáticos extremos.

  

❗**Problema e a solução:** O ClimaConecta é uma plataforma colaborativa que permite que comunidades registrem, compartilhem e monitorem condições climáticas em tempo real, promovendo conscientização e resposta rápida a eventos extremos (como enchentes, secas, tempestades etc.).

  

Nas comunidades, a falta de informação rápida e confiável sobre enchentes e temporais é um problema grave que coloca vidas e propriedades em risco. Muitas vezes, os alertas oficiais não chegam a tempo ou são muito genéricos, sem detalhes sobre riscos específicos em cada rua ou viela. Quem está fora de casa, trabalhando ou estudando, muitas vezes só descobre que a enchente chegou quando já é tarde demais.

  

É aí que entra o ClimaConecta, uma plataforma feita pela comunidade e para a comunidade, onde os próprios moradores podem registrar e compartilhar informações em tempo real sobre alagamentos, tempestades e outros riscos climáticos. A ideia é simples: se o rio começa a subir, um morador abre o app e posta um alerta. Esse aviso é imediatamente postado no ClimaConecta, permitindo que as pessoas se preparem ou tomem as providências necessárias.
## Integrantes do grupo

<div align="center">

| Nome | RM |  
| ------------- |:-------------:|  
| Arthur Eduardo Luna Pulini|554848|  
|Lucas Almeida Fernandes de Moraes| 557569 |  
|Victor Nascimento Cosme|558856|

</div>

## Instalação do projeto - Orientações
#### Credenciais

Para rodar o projeto, é necessário inserir as credenciais do banco de dados Oracle da FIAP no arquivo `appsettings.Development.json`.

#### Aplicação das entidades em tabelas no banco de dados

Após inserir as credenciais, deve-se abrir o Packet Manager Console (Tools > NuGet Package Manager > Package Manager Console) e inserir o comando: `update-database` de modo que as entidades sejam refletidas em banco de dados.

#### Rodar o projeto

Feito isso, basta inicializar o projeto via **HTTP** (não HTTPS) e o Swagger da API será aberto automaticamente. Caso isso não ocorra, ele pode ser acessado através da URL `http://localhost:5045/swagger/index.html`.

## Estrutura do Projeto
```
Application/
├── Dto/
│   ├── EnderecoDto.cs
│   ├── PostDto.cs
│   └── UsuarioDto.cs
├── Interfaces/
│   ├── IEnderecoService.cs
│   ├── IPostService.cs
│   └── IUsuarioService.cs
└── Services/
    ├── EnderecoService.cs
    ├── PostService.cs
    └── UsuarioService.cs

Configurations/
└── AutoMapperProfile.cs

Domain/
├── Entities/
│   ├── EnderecoEntity.cs
│   ├── PostEntity.cs
│   └── UsuarioEntity.cs
└── Interfaces/
    ├── IEnderecoRepository.cs
    ├── IPostRepository.cs
    └── IUsuarioRepository.cs

Infrastructure/
└── Data/
    ├── AppData/
    │   └── ApplicationContext.cs
    ├── Migrations/
    │   ├── 20250513031925_initdb.cs
    │   └── ApplicationContextModelSnapshot.cs
    └── Repositories/
        ├── EnderecoRepository.cs
        ├── PostRepository.cs
        └── UsuarioRepository.cs

Presentation/
└── Controllers/
    ├── EnderecoController.cs
    ├── PostController.cs
    └── UsuarioController.cs

Utils/
└── ApiDoc.cs
```

## Roteiro de Testes - Criação e Atualização
Para testes, sugiro utilizar estes objetos:
### Usuário
#### Criação
```json
{
  "Id": 0,
  "Nome": "João Silva",
  "Cpf": "12345678901",
  "DataNascimento": "1990-05-15",
  "EnderecoId": null
}
```
#### Atualização
```json
{
  "Id": // insira o ID gerado na criação do usuário aqui
  "Nome": "João da Silva Souza",
  "Cpf": "12345678901",
  "DataNascimento": "1990-05-15",
  "EnderecoId": null
}
```
### Endereço
#### Criação
```json
{
  "Id": 0,
  "Logradouro": "Rua das Flores",
  "Numero": "123",
  "Cep": "12345678",
  "Complemento": "Apto 101",
  "UsuarioId": // Insira o ID gerado na criação do usuário aqui 
}
```
#### Atualização
```json
{
  "Id": // Insira o ID gerado na criação do endereço
  "Logradouro": "Avenida dos Lagos",
  "Numero": "123",
  "Cep": "12345678",
  "Complemento": "Apto 101",
  "UsuarioId": // Insira o ID gerado na criação do usuário aqui
}
```

### Posts
#### Criação
```json
{
  "Id": 0,
  "Titulo": "Alagamento na Rua das Palmeiras",
  "Descricao": "Água até a altura do umbigo na Rua das Palmeiras e subindo rápido",
  "DataCriacao": "2025-01-15T10:00:00",
  "UsuarioId": // Insira o ID do usuário criado
}
```
#### Atualização
```json
{
  "Id": // Insira o ID gerado na criação aqui
  "Titulo": "Alagamento na Rua das Pitangas",
  "Descricao": "Água até a altura do umbigo na Rua das Pitangas e subindo rápido",
  "DataCriacao": "2025-01-15T10:00:00",
  "UsuarioId": // Insira o ID do usuário criado
}
```
## Endpoints da API

  

### **Usuários**

  

-  `GET /api/usuario/{id}` → Busca usuário por ID

-  `GET /api/usuario/{cpf}` → Busca usuário por CPF

-  `POST /api/usuario` → Cadastra novo usuário

-  `PUT /api/usuario/{id}` → Atualiza usuário existente

-  `DELETE /api/usuario/{id}` → Remove usuário

-  `GET /api/usuario` → Lista todos os usuários

  

### **Posts**

  

-  `GET /api/post/{id}` → Busca post por ID

-  `GET /api/post/por-usuario/{usuarioId}` → Lista posts por ID de usuário

-  `POST /api/post` → Cria novo post

-  `PUT /api/post/{id}` → Atualiza post existente

-  `DELETE /api/post/{id}` → Remove post

-  `GET /api/post` → Lista todos os posts

  

### **Endereços**

  

-  `GET /api/endereco/{id}` → Busca endereço por ID

-  `GET /api/endereco/por-cep-numero?cep={cep}&numero={numero}` → Busca endereço por CEP e número

-  `POST /api/endereco` → Cadastra novo endereço

-  `PUT /api/endereco/{id}` → Atualiza endereço existente

-  `DELETE /api/endereco/{id}` → Remove endereço

-  `GET /api/endereco` → Lista todos os endereços
