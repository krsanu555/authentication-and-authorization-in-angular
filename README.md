# Authentication and Authorization Using JWT in Angular and .Net Web API
# Project Title

In this Project I have done authentication and authorization using JWT where I have used Angular 8 in front end and  Asp.Net Web API in backend. Here Server will create JWT token after authenticating users and send this token back to client side as response which will be stored in local storage of the browser. After then in each request from client,this token will be send automatically in header of that request which will be verified at the server before processing request.

# Getting Started

In this repository we have two separate project JWTAngular(Angular 8) and JWTImplementationMVC(Asp.Net Web API).
Clone or Download this Project on your local machine to run it. Only thing you have to do is install node modules in angular project by using "npm Install" command in angular project root directory.

# Prerequisites

What things you need to install the software and how to install them
1.NodeJs for running angular project on your machine
Go to the Angular Project Root Directory "JWTAngular" and run this following command

npm install

ng serve

After then open any browser and open this url

http://localhost/4200

2.Visual Studio/Dotnet for hosting your web api locally

Open JWTImplementationMVC project using Visual Studio or in case you have Dotnet installed in your PC, Go in the project root directory and run following command 

dotnet build

dotnet run

# Meta

Kumar Sanu – @krsanu555[https://github.com/krsanu555] – krsanu555@gmail.com

https://github.com/krsanu555/AuthenticationAuthorization

# Acknowledgments

Hat tip to everyone whose reference used

