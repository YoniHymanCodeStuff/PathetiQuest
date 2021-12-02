# PathetiQuest
Midterm project for HackerU submitted by Yoni Hyman

## Concept

As someone who has spent a lot of time playing video games, I wanted to see how I could use sql and EF as a database for the game data
 and save files of a basic fantasy-adventure game. Although the product is far from glamorous and more of a proof of concept than  actually a fun game to play,
 I learned a lot in the proccess and think that I managed to create an amusing thing that should cover all of the bases. 
 
 The general idea, is that (if this was actually a game I thought was fun and worth publishing) the game would be available to different
 people to take the game and through the "Mod" setting create their own modifications of the game, and to try to get the game to 
 be more enjoyable and balanced through editing the game data, but without needing to touch the code. If that happened I would
 need to add a section to the readme with a few minor warnings on what not to do when editing the tables if you want the game to 
 still work as it should. 
 
## Project requirement-fullfilment
 
 In general the project fullfils the task requirements, and so I won't go into unnecessary details about everything easily apparent.
 This section is for specifying the  demands that might not be obvious how I fullfilled. 
 
 ### Design Patterns
 
 My program implements: 
 
 - singleton -"CurrentGameState" is a singleton that holds all of the data that needs to be accessible globally throughout the program.
 - Repository Pattern + Unit of work - I have implemented these patterns (in EF->DataAccess) in order to decouple my database from my program, 
 and to create generic functions to pull data. 

 
 ### multi-tier user management
 
 There is a standard user login sequence, which seems to only have one level of users. However, if you enter the  username and
 password for a "Moderator" user, you get to a separate "mod" menu.  
 
 ### "Join" and various data manipulation operations
 
 Many of my entity types inherit from my "Unit" entity type.  Therefore the way it seemed to make the most sense to me organize the data was to
 have a main table with all the "unit" information, and have all the children entities have tables with the data specific only to them. 
 As a result - whenever i pull a child of "unit" from the table, in terms of the sql I am joining data from the "unit" table with the data from
 the child table. 
 
 In addition, the functions I wrote for lazy loading various types of entities directly pull the linked entities from their respective tables. 
  
 ## Set-up and gameplay
 
**The program needs no external migrating.**
**Just Run the program**, and if you have sql installed it should ("lazily") set up the database. 

The program automatically generates one default "Mod" level user. To access that just log in with the username and password "default". 
Once logged in as a mod you have access to all of the game data and can create more "mod" accounts. 

In-game as with many games of this sort - If you aren't sure what to do - the game is probably waiting for you to press enter. 
I have been told this may not be intuitive and obvious. 
 
 ## Known Issues
 ### backwards UI
 Originally I planned out a lot of the program pretty meticulously and started building it up. My original plan was to have the UI
 be loosely coupled from the program, and just have the program call an object that hides the ui through dependency injection.
 
 When I got around to finally creating the UI with winforms I realized i had made a mistake. Winforms and other UI building
 platforms are built so that they manage the program. the form is supposed to be the main body of the program that calls whatever 
 other layers you have. I had already built a lot of my program in an opposite paradigm. My program was calling the ui similar to
 what I had been used to with console applications. 
 
 Instead of scrapping my product and starting over, I found a strange workaround that lets my program call the UI.
 In doing so I made program much more tightly coupled with the UI than I had wanted to, and I made a big mess in my program that I do not have time
 to properly clean up and re-order before this is due... 
 
 ### All work and no play...
 
 This game is currently not a very fun game. games should probably be fun. 
 This project was more of a proof of concept than anything else so that doesn't really concern me right now... 
 
 ### extra features
 
 some things I wanted to change but might not have a chance: 

 - make ui more responsive
 - encrypt passwords
 - clean up code and try to properly decouple from UI
