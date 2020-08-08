# song-recomendation-api
Microservice API  created to register a user and recommend songs based on hometown

 ## Architecture
 This application contains three microservices and each one is responsible for a specific action over the business rules.

When you login into the application you receive a JWT token and to use this token the Song Recomendation Microservice and the Log Microservice have to access the API Gateway and validate the token received (and saved somewhere, e.g. navigator local storage) over the User Microservice.

 ### API Gateway
 Used to allow communication between the microservices and between them and the user.

 - Ocelot: .NET Core open source (MIT) tool used as API Gateway to use in a microservice envrionment.

 ## Microservices

 ### User Microservice
 - JWT (authorization): Token to authorize a user to access the application;
 - Identity (authentication): Used to create the user authentication.

 ### Song Recomendation Microservice
 - Redis (caching database): Add performance into the application because the temperature of a city does not
 change easily. 

 ### Log Microservice

 - RabbitMQ: Enqueue the log requests to persist on a database (maybe use elasticsearch).

 ## Application usage

  To access the application you need, in first place, to create an user account at the endpoint [[/api/user-service/user]]. After that, you need to login into the application at the endpoint [[/api/user-service/user/login]].
