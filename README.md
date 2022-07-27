# dev-challenge-webapi
# Soluçao do desáfio para criar uma aplicação rest em C#.
* O Desáfio pede para elaborar uma interface gráfica em C# para poder criar, listar e editar os dados de um produto e sincronizar com a API do Reqwest.
* O desáfio também pede que as seguintes condiçoões sejam satisfeitas:
  - Ao criar os dados de um produto a partir da GUI deverá guardar na API do Reqwest e guardar localmente na base de dados SQL Server;
  - Ao editar os dados do produto a partir da GUI deverá atualizar os dados na API do Reqwest e guardar localmente na base de dados SQL Server.

# Esse repositorio contém apenas o código do servidor local (API LOCAL)
* Responsavel por efectuar as operaçoes de criação edição e retornar os produtos da base de dados local.
* Para ver o código do cliente rest(desktop app) clique no link <a href="https://github.com/HarrissonRichard/dev-challenge-desktop-client" target="_blank">Cliente Rest - Desktop App </a>

# Tecnologias
- SQL SERVER
- DAPPER
- ASP.NET Core Web API

# Funcionalidades:
* Visualizar todos os produtos na base de dados local SQL SERVER - GET /products
* Visualizar um produto produto específico -  GET /products/{id}
* Adicionar um novo produto na base de dados local. - POST /products
* Editar dados de um produto e actualizar localmente - /PUT /products/{id}

# DEMO
* para ver uma demonstração das funcionalidades API na Desktop App clique no link <a href="https://youtu.be/-x6EJRh0ELA">DEMO</a> 

# Testes
- 1. para executar localmente, a aplicação depende de .NET 5.0 SDK
- 2. Clonar este repositótio e executar o comando <b>dotnet run</b> para iniciar a aplicação.
* 3. Para acessar a aplicação pode ser através:
  - do navegador com o link  <a herf="https://localhost:5001/swagger"> https://localhost:5001/swagger </a> ou <a href="http://localhost:5000"> http://localhost:5000/swagger </a> 
  - ou usando um cliente rest como postman com o link <a href= "https://localhost"> https://localhost:5001 </a> ou <a href= "http://localhost"> http://localhost:5000 </a>

# Sobre mim
Harrisson Richard
- <a href="https://www.linkedin.com/in/harrisson-richard/">LinkedIn</a>
