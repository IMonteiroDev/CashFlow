## 💰 Sobre o projeto

Esta **API**, desenvolvida em **.NET 8**, aplica os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução sólida e escalável no **gerenciamento de despesas pessoais**.
Seu objetivo é permitir que os usuários registrem e gerenciem despesas com detalhes como **título, data e hora, descrição, valor e tipo de pagamento**, armazenando tudo de forma segura em um banco de dados **MySQL**.

A aplicação segue a arquitetura **REST**, utilizando métodos **HTTP** padrão para uma comunicação simples e eficiente.
Além disso, conta com uma documentação **interativa via Swagger**, que facilita a exploração e os testes dos endpoints.

Entre os principais pacotes NuGet utilizados:

- **AutoMapper** – realiza o mapeamento entre objetos de domínio e DTOs, reduzindo código repetitivo e aumentando a produtividade.

- **FluentValidation** – implementa regras de validação de forma clara e intuitiva nas classes de requisição, mantendo o código limpo e consistente.

- **FluentAssertions** – torna os testes de unidade mais legíveis, expressivos e fáceis de manter.

- **Entity Framework Core** – atua como ORM, simplificando a comunicação com o banco de dados e eliminando a necessidade de escrever consultas SQL manuais.

## 🚀 Features

-   **Domain-Driven Desing (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.

-   **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.

-   **Geração de Relatórios**: Capacidade de exportar relatórios detalhados para **PDF** e **Excel**, oferecendo uma análise visual e eficaz das despesas.

-   **RESTfull API com Documentação Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

### 🧰 Construído com

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

## 🛠️ Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### ✅ Requisitos

-   Visual Studio ou Visual Studio Code
-   Windows 10+ ou Linus/MacOS com [.NET SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) instalado
-   MySql Server

### ⚙️ Instalação

1. Clone o Repositorio:

```sh
git clone https://github.com/IMonteiroDev/CashFlow.git
```

2. Preenche as informações no arquivo `appsettings.Development.json`:

```sh
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;
                Database={Nome do banco de dados};
                Uid=root;
                Pwd={Senha do seu banco de dados};"
  }
}

```

3. Execute a API e aproveite o seu teste

<!-- Links -->

[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Images -->

[hero-image]: images/heroimage.png

<!-- Badges -->

[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
