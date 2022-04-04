# Arkhi.FTGO
Projeto desenvolvido visando uma arquitetura contemplando 5 microserviços, com um deles implementando o pattern CQRS.

![diagrama.png](https://microservices.io/i/patterns/data/QuerySideService.png)
## Sumário
* [Informações Gerais](#informações-gerais)
* [Tecnologias](#tecnologias)
* [Patterns](#patterns-abordados-no-projeto)
* [Setup K8S](#setup-k8s)
* [Setup Manual](#setup-manual)
* [Agradecimentos](#agradecimentos)

## Informações Gerais
Um ponto que ficou pendente no projeto que seria bem interessante implementar seriam os testes unitários e os testes de integração. Quando tiver mais tempo implementarei os mesmos utilizando os seguintes frameworks/packages:
* FluentAssertions
* NSubstitute
* NBuilder
* xunit

### Implementação do CQRS
Minha abordagem no entendimento da implementação do CQRS no microserviço de `OrderHistory` foi a de justamente desacoplar completamente a `Query` do `Command`. É visível no projeto que para qualquer commando de query realizado, não têm-se nenhuma chamada de service, nem sequer através do Container IOC. Os dois estão completamente desacoplados.

### Cadê o accounting service?
Enquanto eu fazia a modelagem de dados eu decidi desconsiderar o accounting service, e substitui ele com o `Customer Service`. Que como o nome já diz, será responsável pelo usuário/consumidor.

## Tecnologias
Foi utilizado:
* ASP.NET Core
* .NET 5
* MassTransit como EventBus
* RabbitMQ
* Kubernetes
* Docker
* MSSQL
## Patterns abordados no projeto
* CQRS
* DDD
* Event Sourcing
* Microservices
## Setup K8S
Existem duas formas de rodar o projeto, a mais simples seria tendo o Docker e o Kubernetes configurado em sua maquina. Tendo o docker e o kubernetes, basta baixar a [pasta k8s](https://github.com/tcortega/Arkhi.FTGO/tree/master/k8s) do repositório e executar os seguinte comandos:
```
$ kubectl create secret generic mssql --from-literal=SA_PASSWORD="passw0rd!"
$ kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.2/deploy/static/provider/cloud/deploy.yaml
$ kubectl apply -f local-pvc.yaml
$ kubectl apply -f mssql-plat-depl.yaml
$ kubectl apply -f rabbitmq-depl.yaml
$ kubectl apply -f ingress-srv.yaml
$ kubectl apply -f customers-depl.yaml
$ kubectl apply -f orders-depl.yaml
$ kubectl apply -f kitchens-depl.yaml
$ kubectl apply -f deliveries-depl.yaml
$ kubectl apply -f orderhistory-depl.yaml
```
Após ter feito tudo isso, para utilizarmos o api gateway que foi configurado através do Ingress NGINX, será necessário fazer o redirecionamento de um domínio que eu mesmo escolhi, para o seu localhost. Então basta adicionar as seguintes linhas no seu arquivo `hosts`.
```
127.0.0.1 arkhi.ftgo.com
```
Após isso, o projeto estará pronto para ser utilizado. Basta acessar no seu navegador os endpoints que foram configurados dentro de `k8s/ingress-srv.yaml`. Como por exemplo: `http://arkhi.ftgo.com/api/customers/swagger`.
## Setup Manual
A segunda forma de rodar é sem o kubernetes, para isso a forma mais rápida seria clonar o projeto inteiro, e ir em cada serviço e utilizar do comando dotnet run para rodar. Lembrando que desta forma, você precisará subir o servidor MSSQL e o RabbitMq manualmente para que possa ser utilizado. E talvez será necessário atualizar os arquivos `appsettings.json` com connection strings diferentes.

## Agradecimentos
Esse projeto fez com que eu conhecesse muito mais da área de devops, microserviços e os patterns implementados. Agradeço pelo desafio proposto que me fez abrir o olho pro quão complexo e longo um tópico que possa parecer simples como os microsserviços, pode ser. Eu sequer imaginava que teria tanto desafio e tanta coisa pra aprender desenvolvendo essa aplicação então ela serviu de um aprendizado enorme para mim.