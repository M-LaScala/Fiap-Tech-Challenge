# Postech Arquitetura de Sistemas com .Net
# Fase 1 - Tech.Challenge.Grupo27 4NETT

[![Build Status](https://dev.azure.com/POSTECHFIAPGRUPO27/POSTECH-ARQUITETURA/_apis/build/status%2FPOSTECH-ARQUITETURA-.NET%20Core%20with%20SonarCloud-CI?branchName=main)](https://dev.azure.com/POSTECHFIAPGRUPO27/POSTECH-ARQUITETURA/_build/latest?definitionId=4&branchName=main)

## Descri��o
Projeto desenvolvido para a fase 1 de Arquitetura de Sistemas com .Net.

### Requisitos funcionais
Cadastro de contatos: permitir o cadastro de novos contatos, incluindo nome, telefone e e-mail. Associe cada contato a um DDD correspondente � regi�o.
Consulta de contatos: Implementar uma funcionalidade para consultar e visualizar os contatos cadastrados, os quis podem ser filtrados pelo DDD da regi�o.
Atualiza��o e exclus�o: possibilitar a atualiza��o e exclus�o de contatos previamente cadastrados.

### Requisitos t�cnicos
Persist�ncia de dados: utilizar um banco de dados para armazenar as informa��es dos contatos. Escolha entre Entity Framework Core ou Dapper para a camada de acesso a dados.
Valida��o de dados: implementar valida��es para garantir dados consistentes (por exemplo: valida��o de formato de e-mail, telefone, campos obrigat�rios).
Testes de unidade: desenvolver testes de unidade utilizando xUnit ou NUnit.

### Entrega
Para que possamos avaliar, esperamos um v�deo demonstrando os passos utilizados para o desenvolvimento do projeto, a arquitetura escolhida, o banco de dados e principalmente o projeto funcionando com os requisitos b�sicos.

Observa��o: O foco principal � a qualidade do c�digo, as boas pr�ticas de desenvolvimento e o uso eficiente da plataforma .Net8. Este desafio � uma oportunidade para demonstrar habilidades em persist�ncia de dados arquitetura de software e testes, al�m de boas pr�ticas de desenvolvimento.

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
 Foi utilizado o padr�o de arquitetura DDD (Domain-Driven Design) para a organiza��o do projeto. A arquitetura foi dividida em 4 camadas:
- API: Camada de apresenta��o, respons�vel por receber as requisi��es HTTP e retornar as respostas.
- Application: Camada de aplica��o, respons�vel por orquestrar as chamadas entre a API e a camada de dom�nio.
- Domain: Camada de dom�nio, respons�vel por representar as entidades do neg�cio e as regras de neg�cio.
- Infrastructure: Camada de infraestrutura, respons�vel por implementar os contratos definidos na camada de dom�nio.

## Qualidade de Software
- Utiliza��o do SonarCloud: Ferramenta de an�lise est�tica de c�digo que identifica problemas de qualidade de c�digo, bugs, vulnerabilidades e code smells.
- Testes: Camada de testes, respons�vel por implementar os testes de unidade.
- Stryker Mutator: Ferramenta de muta��o de c�digo que identifica a efic�cia dos testes de unidade.
- Code Coverage: Ferramenta de an�lise de cobertura de c�digo que identifica a porcentagem de c�digo coberto pelos testes.
