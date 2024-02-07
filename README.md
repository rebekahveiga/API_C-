# Projeto API

Este documento README detalha os principais aspectos e funcionalidades que implementei no projeto de API.

## Funcionalidades Implementadas

### Comunicação com o Mundo Externo e Configuração de Rotas

- **Controllers e Rotas:** Implementei controllers para abrir a comunicação do serviço com o mundo externo, definindo rotas específicas que direcionam as requisições HTTP para os controllers apropriados. 
- **Extensões de Controller:** Aproveitei extensões para os controllers para expandir suas funcionalidades, melhorando assim a reutilização do código e a manutenção geral do projeto.
- **Injeção de Dependência:** Usei a injeção de dependência no construtor dos controllers, facilitando o gerenciamento das dependências e promovendo um design de software limpo e testável.
- **Verbos HTTP nas Actions:** Defini as actions dentro dos controllers com verbos HTTP específicos (GET, POST, PUT, DELETE, PATCH), garantindo que as operações CRUD (Create, Read, Update, Delete) sejam realizadas.

### Implementação de Paginação

- Implementei a funcionalidade de paginação para as respostas das requisições. 

### Integração com Entity Framework e MySQL

- **Entity Framework:** Utilizei o Entity Framework para estabelecer e gerenciar a comunicação com o banco de dados MySQL. Isso facilita a manipulação dos dados e a implementação de operações de banco de dados, como consultas, inserções, atualizações e exclusões, de forma mais eficiente e segura.

### Práticas com DTOs

- **DTOs e Boas Práticas:** Adotei o uso de DTOs (Data Transfer Objects) para otimizar a transferência de dados entre diferentes camadas da aplicação.


