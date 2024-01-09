# Projeto de API seguindo conceito de DDD (Domain-Driven Design)

Este é um projeto de exemplo de uma API integrada com SQL Server seguindo os princípios do Domain-Driven Design (DDD). Foi desenvolvido para fins de estudo e aprendizado, com o foco e objetivo de praticar testes unitários e testes de integração em cima da API.

## Estrutura do Projeto

O projeto está dividido em diferentes camadas, cada uma com sua responsabilidade:

- `Domain`: Contém as entidades, objetos de valor, interfaces de repositório e serviços do domínio.
- `Infrastructure`: Implementações concretas das interfaces definidas no domínio, incluindo acesso a banco de dados, serviços externos, etc.
- `Tests`: Contém os testes unitários e/ou de integração para validar o funcionamento do código.

## Tecnologias Utilizadas

- Linguagem de Programação: *C#*
- Frameworks Utilizados: *Entity Framework*
- Ferramentas de Teste: *xUnit, Moq*
