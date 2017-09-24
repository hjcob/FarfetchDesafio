# Farfetch - Desafio

# Soluções Utilizadas <br/>
- MiddleWare Owin para interceptar os paths e verificar dinamicamente se os mesmos estão disponíveis  <br/>
- Redis para guardar o cache dos serviços que estão disponívels (conta free RedisLabs)<br/>
- Apis de serviços  <br/>
- Apis para controle do middleware (habilitar e desabilitar os serviços <br/>
- Projeto de testes onde tem a cobertura de todo código por teste de integração <br/>

# Justificativas <br/>
 - Poderiam ser utilizadas outras abordagens para resolução do problema, mas achei essa com o menor custo de implementação e quantidade de linhas de código. <br/>
 - Poderia usar Postsharp Pro para interceptar a chamada do service e em um before verificar se ele poderia responder, mas acho que ficaria mais lento<br/>
 - Como é um projeto de testes, não implementei LOG, UI, UoW, soluções complexas para acesso a dados ou tratamento de exception. <br/>
 
 # Úteis <br/>
 ## Comandos Postman que podem ser úteis verbo POST <br/>
 ### Rodar o projeto Farfetch.Services como startup project <br/>
  - http://localhost:8087/api/farfetch/v1/gateway/blockallservices (bloqueia todos os serviços) 
  - http://localhost:8087/api/farfetch/v1/gateway/unblockallservices (desbloqueia todos os serviços)
  
 Obrigado!
 
