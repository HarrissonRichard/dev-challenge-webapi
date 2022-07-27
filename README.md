# dev-challenge-webapi
# Soluçao do desáfio para criar uma aplicação rest em C#.
O desáfio pede que as seguintes condicoes sejam satisfeitas:
- Ao criar os dados de um produto a partir da GUI deverá guardar na API do Reqwest e guardar localmente na base de dados SQL Server;
- Ao editar os dados do produto a partir da GUI deverá atualizar os dados na API do Reqwest e guardar localmente na base de dados SQL Server.

# Esse repositorio contem o código do servidor(webapi)

#Tecnologias
- SQL SERVER
- DAPPER
- ASP.NET Core Web API

# Funcionalidades
a presente aplicação apresenta as seguintes funcionalidades:
* Visualizar todos os produtos na base de dados local SQL SERVER GET /products
* Visualizar um produto produto especifico GET /products
* Adicionar um novo produto na base de dados local e remota(Rekwest). POST /products
* Editar dados de um produto e actualizar localmente /PUT /products/{id}

# Testes
- para testar a aplicação é preciso antes iniciar o servidor, cujo o código está nesse <a href="https://github.com/HarrissonRichard/dev-challenge-webapi">repositório</a> para que possa persistir os dados localmente  e depois sincroniza-los remotamente com API rekwest.
- 1. para executar localmente, a aplicação depende de .NET 5.0
- 2. executar o comando <b>dotnet run</b> para iniciar a aplicação.
* 3. para acessar a aplicacao pode ser através do navegador com o link link <a herf="https://localhost:5001/swagger"> https://localhost:7065/swagger </a> ou usando um cliente rest como postman

# Sobre mim
Harrisson Richard
- <a href="https://www.linkedin.com/in/harrisson-richard/">LinkedIn</a>
