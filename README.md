
# Beer2Beer Forum

A forum devoted to beer cicerones.



## Task Description

Design and implement a Forum System, where the users can create posts, add
comments, and upvote/downvote the things that they like or dislike the most.
Choose what your forum will be about and stick with it. This is a forum for everyone that likes beers :).

We are using C# Web API, together with Entity Framework (Microsoft SQL Server) to create the backend of the forum. The frontend is developed with Angular JS.

## Deployment - Local Run

The backend and frontend part of the application are deployed separetely

1. Backend
For this part you will need Visual Studio 2022. Open the Beer2Beer.sln fil and make sure to run Beer2Beer.Web using IIS Express. From there the Swagger (OpenAPI) documentation will be shown on this 
url:

```bash
  https://localhost:44305/
```

2. Frontend
For this part you will need to have Node.js installed and Visual Studio Code (this one is optional). Navigate to the Beer2Beer.UI folder. If you have Visual Studio code open the folder there and open a terminal. Otherwise open CMD in the same directory. Run the folling command to install all required packeges:

```bash
  npm install -g @angular/cli
  npm install
```
From here type out the following command to initiate the developer preview of the app (Backend requied):
```bash
  ng serve -o
```
To bundle the web application use:
```bash
  ng build
```
If you are using Visual Studio Code these commands are preloaded in the npm scripts section.
## Databaase Relations

![App Screenshot](https://i.imgur.com/R09hrIy.png)


## Authors

- [Georgi Kostov](https://gitlab.com/G3rg1)
- [Kaloyan Maksimov](https://gitlab.com/k.maksimov)
- [Alexander Alexandrov](https://gitlab.com/alexandrov41)



## Acknowledgements

 - [Telerik Academy](https://www.telerikacademy.com/)
 Thank you for giving us this awsome challange as our Web Teamwork Project!
