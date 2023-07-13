# SOBRE API - Car Registration

O que é a aplicação ? A aplicação tem a finalidade de cadastrar veículos novos ou semi-novos, para revendas.

<h3>Orientações:<h3>
<ul>
  <li>Realize o clone da aplicacão git@github.com:iagolucas2020/APICarRegistration.git;</li>
  <li>Garanta que tenha instalado em sua máquina (Visual Studio, .net 6.0, Sql Server, SGBD para gerenciar banco);</li>
  <li>Rode o projeto e faça as chamadas nas API, por meio do swagger;</li>
</ul>

<h3>Diagrama Entidade Relacionamento:<h3>
<ul>
  <li>Carros - representam os veiculos a ser cadastrados;</li>
  <li>Categoria - representa a categoria do veiculo;</li>
  <li>Modelo - Especifica o modelo do veiculo;</li>
  <li>Marca - Especifica a marca;</li>
</ul>

<img src="https://i.postimg.cc/D0yYvJ7n/Captura-de-tela-2023-07-12-160018.png" alt="Girl in a jacket">

<h3>Tecnologias Utilizadas:<h3>
<ul>
  <li>C#</li>
  <li>Asp.Net Core .Net 6.0</li>
  <li>Sql - Utilizando o SGBD- SQL Server Management Studio</li>
</ul>
<h3>Acesso ao banco com biblioteca Entity Framework;<h3>
<h3>Foi realizado testes unitários das classes utilizando biblioteca fluent Assert;<h3>

<h2>End Points<h2>
<h3>Brands<h3>
<ul>
  <li>GET    /Brands</li>
  <li>POST   /Brands</li>
  <li>GET    /Brands/{id}</li>
  <li>PUT    /Brands/{id}</li>
  <li>DELETE /Brands/{id}</li>
</ul>

```json
{
  {
    "name": "string"
  }
}
```
  
<h3>Cars<h3>
<ul>
  <li>GET    /Cars</li>
  <li>POST   /Cars</li>
  <li>GET    /Cars/{id}</li>
  <li>PUT    /Cars/{id}</li>
  <li>DELETE /Cars/{id}</li>
</ul>

```json
{
  {
    "description": "string",
    "price": 0,
    "modelYear": "stri",
    "manufactureYear": "stri",
    "registerDate": "2023-07-13T16:48:26.591Z",
    "imageUrl": "string",
    "categoryId": 0,
    "modelId": 0
  }
}
```

<h3>Categories<h3>
<ul>
  <li>GET    /Categories</li>
  <li>POST   /Categories</li>
  <li>GET    /Categories/{id}</li>
  <li>PUT    /Categories/{id}</li>
  <li>DELETE /Categories/{id}</li>
</ul>

```json
{
  {
    "name": "string"
  }
}
```

<h3>Models<h3>
<ul>
  <li>GET    /Models</li>
  <li>GET    /Models/models</li>
  <li>POST   /Models</li>
  <li>GET    /Models/{id}</li>
  <li>PUT    /Models/{id}</li>
  <li>DELETE /Models/{id}</li>
</ul>

```json
{
  {
    "id": 0,
    "name": "string",
    "brandId": 0
  }
}
```
