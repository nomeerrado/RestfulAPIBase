# RestfulAPIBase

Esta é uma API RESTful para autenticação de usuários e controle de acesso através de tokens Bearer.

# Tecnologias Utilizadas

.NET 8  
Swagger

# Configuração e Instalação

> Instruções sobre como configurar e instalar a API em um ambiente de desenvolvimento local via comandos.

1. Clonar o repositório:  
git clone https://github.com/nomeerrado/RestfulAPIBase.git

2. Navegar até a pasta do projeto:  
cd RestfulAPIBase/RestfulAPIBase

3. Instalar as dependências:  
dotnet restore

4. Executar a aplicação:  
dotnet run

# Uso

> Instruções sobre como utilizar a API em um ambiente de desenvolvimento local.

1. Com a API e o Swagger já iniciados, realize o login com as seguintes credenciais:  
**username: sample**  
**password: 123**  

2. Inclua o token Bearer no cabeçalho de autorização de suas requisições para endpoints protegidos:  

> Você poderá copiar o token Bearer do retorno da requisição de login, caso a credencial informada válida.

> Lembre-se de adicionar o prefixo Bearer, exemplo: **Bearer Seu_Token**

![swagger_auth](https://github.com/nomeerrado/RestfulAPIBase/assets/63516704/69e5672b-8d01-4891-932e-dac82277a91b)

