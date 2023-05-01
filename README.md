# PathetiQuest
A Text based fantasy game, using winforms for UI, and dotnet with Entity framework as the backend. Originally submitted as a Midterm project for HackerU's fullstack dotnet course. 

## Concept

As someone who has spent a lot of time playing video games, I wanted to see how I could use sql and EF as a database for the game data and save files of a basic fantasy-adventure game. Although the product is far from glamorous and more of a proof of concept than  actually a fun game to play, I learned a lot in the proccess and think that I managed to create an amusing thing while covering the project requirements. 
 
 The general idea, is that (if this was actually a game I thought was fun and worth publishing) the game would be available to different people to take the game and through the "Mod" setting create their own modifications of the game, and to try to get the game to be more enjoyable and balanced through editing the game data, but without needing to touch the code. If that happened I would  need to add a section to the readme with a few minor warnings on what not to do when editing the tables if you want the game to still work as it should. 
 
 
 ### Design Patterns
 
 My program implements: 
 
 - singleton -"CurrentGameState" is a singleton that holds all of the data that needs to be accessible globally throughout the program.
 - Repository Pattern + Unit of work - I have implemented these patterns (in EF->DataAccess) in order to decouple my database from my program, and to create generic functions to pull data. 

 
 ### multi-tier user management
 
 There is a standard user login sequence, which seems to only have one level of users. However, if you enter the  username and
 password for a "Moderator" user, you get to a separate "mod" menu.  


### General architecture notes

Before working on this project the only programs I had written were console applications whose starting point were my code. I didn't realize that with a winforms app the flow of command is from the UI, and the program just has to respond to it. I only realized this mistake rather late in the proccess. Instead of scrapping what I had already written, I created a creative if unorthodox workaround that lets the UI run in parralel to my code loops. The result is creative and functional, but not optimal. 




 ## Set-up and gameplay
 
**The program needs no external migrating.**
**Just Run the program**, and if you have sql installed it should ("lazily") set up the database. 

The program automatically generates one default "Mod" level user. To access that just log in with the username and password "default". 
Once logged in as a mod you have access to all of the game data and can create more "mod" accounts. 

In-game as with many games of this sort - If you aren't sure what to do - the game is probably waiting for you to press enter. 
I have been told this may not be intuitive and obvious. 
 
 ## Known Issues
 ### backwards UI
 Originally I planned out a lot of the program pretty meticulously and started building it up. My original plan was to have the UI  be loosely coupled from the program, and just have the program call an object that hides the ui through dependency injection.
 
 When I got around to finally creating the UI with winforms, my main issue was finding a way to use the code I already wrote together with winforms (see "general architecture notes"). The resulting code effectively tightly coupled the logic layer with the UI, even though I had wanted to avoid that. 
 
   
 ### All work and no play...
 
 This game is currently not a very fun game. games should probably be fun. 
 This project was more of a proof of concept than anything else so that doesn't really concern me right now... 
 
 ### extra features
 
 some things I would change if I revisit this project: 

 - make ui more responsive
 - encrypt passwords
 - clean up code and try to properly decouple from UI, making the logic layer wait for commands from the UI. 
