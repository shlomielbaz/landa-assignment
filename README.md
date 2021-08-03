# Landa Assignment
Layout management rely on C# (server side) and React (client side), with MobX state manager. you can reset your own layout by click on "Configuration" link (top right corner), there you can add, remove, reorder and resize layout items.

### Project Structure:
-- LA.API -   Represent the RESTFul API service, the middleware tire.
-- LA.Data - Represent the database access tier.
-- LA.Domain - Represent the application domain.
-- LA.Service - Represent the service tier, the mediator between the API and the Domain.
-- LA.Web - represent the front-end, the entry point.

### Execute the app using visual studio:
Just start the app, the project sets as a multiple startup projects (API and WEB).

### Execute the app without visual studio:
Get into LA.API project by using powershell and run the command: ```dotnet rum```.
Get into LA.Web/ClientApp with CLI such as powershell/CMD and run the command: ```npm start```.

Note: the server and the client running on different PORTS, the CORS problem resolved by PROXY setting in package.json ("proxy": "http://localhost:5001").
Note: the background color to the layout generated randomly.

The following is an examples of layout results in edit/view modes:
![Edit Mode](./5.png "Layout in edit mode")
![Edit Mode](./4.png "Layout in edit mode")
![Edit Mode](./2.png "Layout in edit mode")
![Edit Mode](./1.png "Layout in edit mode")
