# ParkingBackend

Aplicação para gerenciamento de estacionamento, gerenciando a entrada e saída de veículos e informando o valor a ser pago ao final com base em uma tabela de preços.

Este repositório compreende apenas o back-end do projeto. Para acessar o front-end, por favor, acesse o link [https://github.com/cunhanai/parking-frontend](https://github.com/cunhanai/parking-frontend).

## Tecnologias utilizadas

- **Linguagem:** C#
- **Framework:** .NET Core 8 + Entity Framework
- **IDE:** Visual Studio 2022
- **Banco de dados:** PostgreSQL 15

## Setup

### Alterando connection string do o banco de dados

Atualmente a connection string para conecção com o postgres está definida como <code>Host=localhost;Port=5432;Database=Parking;User Id=postgres;Password=postgres;</code>. É provável que seja necessário alterá-la para funcionar no seu dispositivo caso alguma das informações seja diferente.

Você pode alterá-la indo em <code>Parking.Infra.Data.Context.ParkingContext</code> e alterando a constante <code>CONNECTION_STRING</code> para o valor correto.

### Parâmetros da connection string

- <code>Host</code>: É o local onde a aplicação está hospedada, nesse caso o valor não muda e é o próprio <code>localhost</code>
- <code>Port</code>: É a porta para o qual seu PostgreSQL está apontando, por padrão é <code>5432</code>
- <code>Database</code>: Nome do banco de dados, nesse caso o valor não muda e continua sendo <code>Parking</code>
- <code>User Id</code>: Seu nome de usuário no Postgres, por padrão é <code>postgres</code>
- <code>Password</code>: Senha vinculada ao seu usuário no Postgres, por padrão é <code>postgres</code>

[Ver mais sobre connection strings](https://www.npgsql.org/doc/connection-string-parameters.html)





