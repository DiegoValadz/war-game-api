# War Game

## Overview
The project is a REST API created in Dot Net Core 6 which is consumed by an Angular application for demo purposes.

## Source Code
Here you can get both git repositories to review the code.

 - Backend Github Repositorie
 - Frontend Github  Repositorie

## Access
The solution is hosted on a VPS, you can easily access to the project by the following URLs:

API BASE URL:
- https://war-game-api.diegovaladez.com/api

APP URL:
- https://war-game-app.diegovaladez.com/

## Endpoints
There are FIVE different endpoints created for this project:

| TYPE  | ENDPOINT   | ACTION |
|---|---|---|
| GET |/games/computed   |This is the main action of the solution, it creates a new game and simulates all the events involved on a match. It returns a general "Game" Json object.   |
| GET |/games/{id}   |It returns a Game from the database by it´s ID |
| GET |/players/scores   |This endpoint returns lifetime wins for each player stored in a database. |
| GET |/players/{id}   |It returns a Player from the database by it´s ID  |
| POST |/players  |Creates a new player   |  


## How to generate a game

You can GET the [Generate Computed Game Endpoint] or go into the [Web Application].

The solution follows the rules provided in the requirements, so when a "War" begins, the 
computer just plays face down 1 card and 1 face up card.

> Note: This is important because it increases the chances to get an infinite game and by
consequence a drawn.


## Web Application Features

The War Game Application calls the API and generates a new game, then it basically
shows the turns in the order they were played on the API

- It Shows a header with total wins of each player
- It has two components to render the Deck of the players
- The Game events are showed on a dynamic list component and graphically 
on the above component


   [dot net core 6]: <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>
   [angular]: <https://angular.io/>
   [Backend Github Repositorie]: <https://github.com/DiegoValadz/war-game-api.git>
   [Frontend Github Repositorie]: <https://github.com/DiegoValadz/war-game-app.git>
   [Generate Computed Game Endpoint]: <http://war-game-api.diegovaladez.com/api/games/computed>
   [web application]: <http://war-game-app.diegovaladez.com>
