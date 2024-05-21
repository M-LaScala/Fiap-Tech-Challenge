# Postech Arquitetura de Sistemas com .Net
# Fase 1 - Tech.Challenge.Grupo27 4NETT

[![Build Status](https://dev.azure.com/POSTECHFIAPGRUPO27/POSTECH-ARQUITETURA/_apis/build/status%2FPOSTECH-ARQUITETURA-.NET%20Core%20with%20SonarCloud-CI?branchName=main)](https://dev.azure.com/POSTECHFIAPGRUPO27/POSTECH-ARQUITETURA/_build/latest?definitionId=4&branchName=main)

## Descrição
Projeto desenvolvido para a fase 1 de Arquitetura de Sistemas com .Net.

### Requisitos funcionais
Cadastro de contatos: permitir o cadastro de novos contatos, incluindo nome, telefone e e-mail. Associe cada contato a um DDD correspondente à região.
Consulta de contatos: Implementar uma funcionalidade para consultar e visualizar os contatos cadastrados, os quis podem ser filtrados pelo DDD da região.
Atualização e exclusão: possibilitar a atualização e exclusão de contatos previamente cadastrados.

### Requisitos técnicos
Persistência de dados: utilizar um banco de dados para armazenar as informações dos contatos. Escolha entre Entity Framework Core ou Dapper para a camada de acesso a dados.
Validação de dados: implementar validações para garantir dados consistentes (por exemplo: validação de formato de e-mail, telefone, campos obrigatórios).
Testes de unidade: desenvolver testes de unidade utilizando xUnit ou NUnit.

### Entrega
Para que possamos avaliar, esperamos um vídeo demonstrando os passos utilizados para o desenvolvimento do projeto, a arquitetura escolhida, o banco de dados e principalmente o projeto funcionando com os requisitos básicos.

Observação: O foco principal é a qualidade do código, as boas práticas de desenvolvimento e o uso eficiente da plataforma .Net8. Este desafio é uma oportunidade para demonstrar habilidades em persistência de dados arquitetura de software e testes, além de boas práticas de desenvolvimento.

## Tecnologias utilizadas
- .Net 8
- Entity Framework Core
- Swagger
- Azure DevOps
- SonarCloud
- xUnit
- FluentValidation
- Docker
 
 ## Arquitetura
 Foi utilizado o padrão de arquitetura DDD (Domain-Driven Design) para a organização do projeto. A arquitetura foi dividida em 4 camadas:
- API: Camada de apresentação, responsável por receber as requisições HTTP e retornar as respostas.
- Application: Camada de aplicação, responsável por orquestrar as chamadas entre a API e a camada de domínio.
- Domain: Camada de domínio, responsável por representar as entidades do negócio e as regras de negócio.
- Infrastructure: Camada de infraestrutura, responsável por implementar os contratos definidos na camada de domínio.

## Qualidade de Software
- Utilização do SonarCloud: Ferramenta de análise estática de código que identifica problemas de qualidade de código, bugs, vulnerabilidades e code smells.
- Testes: Camada de testes, responsável por implementar os testes de unidade.
- Stryker Mutator: Ferramenta de mutação de código que identifica a eficácia dos testes de unidade.
- Code Coverage: Ferramenta de análise de cobertura de código que identifica a porcentagem de código coberto pelos testes.
