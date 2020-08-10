# song-recomendation-api
Microservice API  created to register a user and recommend songs based on hometown

 ## Instalation guide
 To use this application you need to have Docker and .NET Core 3.1 installed on your local machine. 
 
 After installing those tools you need to create TWO DIFFERENT DATABASES, one for the User Service and other for the Log Service. 
 
 You can use the current database credentials, they are available for public use and you do so, you don't need to change anything. In case you want to use your own database you need to replace the current database credentials, using the format "Host=YOUR_HOST; Database=YOUR_DATABASE; Username=YOUR_USERNAME; Password=YOUR_PASSWORD", on the files listed below (change in the lines indicated) to your custom database:
  * `song-recomendation-api/CNX.MusicRecomendation/src/LogService/CNX.LogService.Data/DataContext/LogContext.cs`        -> Line 26
  
  * `song-recomendation-api/CNX.MusicRecomendation/src/LogService/CNX.LogService.WebApi/appsettings.json`               -> Line 3
  
  * `song-recomendation-api/CNX.MusicRecomendation/src/LogService/CNX.LogService.WebApi/appsettings.Development.json`   -> Line 3
  
  * `song-recomendation-api/CNX.MusicRecomendation/src/UserService/CNX.UserService.Data/DataContext/UserContext.cs`     -> Line 30
  
  * `song-recomendation-api/CNX.MusicRecomendation/src/UserService/CNX.UserService.WebApi/appsettings.json`             -> Line 3
  
  * `song-recomendation-api/CNX.MusicRecomendation/src/UserService/CNX.UserService.WebApi/appsettings.Development.json` -> Line 3
  
  If you choose to use the current database, you can skip to the `Application usage` section. If you choose to use your own database, run the command below at the path indicated:
  
  Path -> `song-recomendation-api/CNX.MusicRecomendation/src/LogService/CNX.LogService.Data`   -> $ Update-Database
  
  Path -> `song-recomendation-api/CNX.MusicRecomendation/src/UserService/CNX.UserService.Data` -> $ Update-Database 
 
 ## Application usage
  To run the application you need to go to the path `song-recomendation-api/CNX.MusicRecomendation/` and run the command $ docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build. Or you could just set the Docker-Compose as active project in Visual Studio and run the application. After running it, the application is available at [[http://localhost:7000]]
  
  The application runs over a Api Gateway, and the endpoints are listed below:
  
| Service | Endpoint                        | Methods               |
|---------|---------------------------------|-----------------------|
| User    | /user-service/user              | GET, POST, PUT, PATCH |
| User    | /user-service/user/login        | POST                  |
| User    | /user-service/user/validate-jwt | POST                  |
| Weather | /music-recomendation/weather    | GET                   |
| Log     | /log-service/log                | POST                  |

  You can see the Api Gateway route configuration on `song-recomendation-api/CNX.MusicRecomendation/src/ApiGateway/CNX.ApiGateway/ocelot.json`.
  
  After all those steps, you can use the application according to the business rules and the following endpoints:
  
  * `/user-service/user` - POST -> Create an account (Dto to post on body: UserDto).
  
  * `/user-service/user/login` - POST -> Login (Dto to post on body: LoginDto).
  
  * `/music-recomendation/weather` - GET -> Get a playlist recomendation based on user logged (no body required).
  
 ## Future improvements
 - The user service does not accept notes;
 - The user service does not reset the password;
 - The user service does not have a forgot password mechanism;
 - Improve performance while reading city.list.json (to not allocate all the list in memory);
 - Use queue to log the requests;
 - Use redis to cache weather from cities;
  
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
 - Open Weather Api: Api used to that through the id of the city, return the wheather of it.
 - SpotifyWeb Api: Api used to get a playlist based on the city temperature returned from Open Weather Api.

 ### Log Microservice
 - LoggingRequestMiddleware: custom middleware create for logging all the requests on a separeted database.
