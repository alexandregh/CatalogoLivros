# Catálogo de Livros Online
### Sistema Web - Catálogo de Livros Online 
###### Versão 1.0

<p>Projeto Web fictício de uma um Catálogo de Livros chamado Catálogo de Livros Online.</p>

- Projeto: ASP NET 
- Linguagem: C# 
- Tecnologias Back-End: MVC5 + ORM Entity Framework - E.F (Data Annotations) 
- Tecnologias Front-End: HTML5 + CSS3 + JQquery 
- Base de Dados: SQLServer (.mdf). 
- Arquitetura do Projeto: o projeto está dividido atualmente em quatro camadas descritas abaixo: <br />
**CatalogoLivros.Web:** camada responsável pela apresentação contendo a arquitetura de padrão de responsabilidade chamada MVC; <br />
**CatalogoLivros.Util:** camada baseada no conceito Cross-Cutting Concerns* e responsável pelas Operações Utilitárias e Secundárias do Sistema; <br />
**CatalogoLivros.Domain:** camada responsável por todas as entidades de negócio, regras e suas características; <br />
**CatalogoLivros.Interfaces:** camada responsável por todas as Assinaturas dos Métodos (Funcionalidades) que são implementados na camada CatalogoLivros.DAL; <br />
**CatalogoLivros.DAL:** camada responsável pela manipulação de dados; **CatalogoLivros.SGBDDAL:** camada responsável pela fonte de acesso dos dados).

<p>Cross-Cutting Concerns*: São funcionalidades que não estão diretamente relacionadas ao domínio da aplicação ou às suas respectivas regras de negócio, mas que ainda sim, são importantes para o Software. Exemplos: envio de emails, criptografia de senhas, etc.</p>
