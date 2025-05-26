# 🏗️ Developer Evaluation - Sales API 🚀

API desenvolvida para o processo de avaliação técnica da Ambev, utilizando .NET 8, arquitetura limpa, padrões DDD, testes unitários e de integração, além de infraestrutura containerizada com Docker.

---

## ✨ Tecnologias Utilizadas

- ✅ .NET 8
- ✅ ASP.NET Web API
- ✅ PostgreSQL
- ✅ MongoDB
- ✅ Redis
- ✅ Entity Framework Core
- ✅ MediatR (CQRS + Pipeline Behaviors)
- ✅ FluentValidation
- ✅ AutoMapper
- ✅ Serilog (Logging estruturado)
- ✅ xUnit + FluentAssertions + NSubstitute + Bogus (Testes)
- ✅ Docker + Docker Compose

---

## 📦 Arquitetura e Organização

| Camada            | Descrição                                       |
|-------------------|-------------------------------------------------|
| `Domain`          | Entidades, Enums, Specifications, Validations  |
| `Application`     | Handlers, Commands, Queries, Profiles          |
| `ORM`             | Configurações de persistência (EF Core)        |
| `IoC`             | Injeção de dependências                        |
| `WebApi`          | Controllers, Middlewares, Swagger, Pipelines   |
| `Unit Tests`      | Testes de unidades (Domain, Handlers, Validators) |
| `Integration Tests`| Testes end-to-end com banco em memória         |

---

## 🚀 Como Executar Localmente

### 🔥 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)

---

### 🐳 Subindo com Docker

1️⃣ Crie os certificados HTTPS:

```bash
mkdir https
dotnet dev-certs https -ep ./https/aspnetapp.pfx -p senha123
dotnet dev-certs https --trust
