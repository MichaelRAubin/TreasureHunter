# Treasure Hunter
![](https://images.unsplash.com/photo-1501868984184-76121ed6a6e2?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80)
## The Setup
<hr>

As you begin working on a console game the basic requirements of any good console game will allow users to:
  - Move about a set of rooms
  - Get a description of the room they are in
  - Get Help ( show a list of all available commands )
  - Take Items
  - Give Up 
  
To help you out with some of these basic features will notice that you already have some interfaces that have been built. These interfaces are designed to help ensure you implement the basic requirements of a console game. 

### Step 1 -  Satisfy the Interfaces 

To satisfy the interfaces you will need to ensure that your classes implement all of the features of the provided interfaces... You cannot remove anything from any of the interfaces. 
  The Basic Features of the game:
  - `Go <Direction>` Moves the player from room to room
  - `Take <ItemName>` Places an item into the player inventory and removes it from the room
  - `Look` Prints the description of the room again
  - `Inventory` Prints the players inventory
  - `Help` Shows a list of commands and actions
  - `Quit` Quits the Game

### Step 2 - Control the Game Loop
After building the game in the setup, you will need to continually take in user input. Make sure your game loop takes in the user input, handles it updating the game state (changing a room, taking an item, etc.) then takes in a new user command.

Because of how the interfaces are setup, you should be able to follow the pattern that has been laid out to build this functionality over several methods in the `App` class. 
  
## Requirements
<hr>

### Functionality: 
 - Player input must be seperated into either `command` or `command` and `option`

    - look - &lt;command&gt;
    - go north - &lt;command&gt; &lt;option&gt; 
    - take key - &lt;command&gt; &lt;option&gt;
 - Players can move room to room with the `go <direction>` command
 - Items exist for the player to `take` from rooms
 - `quit` ends the game
 - At least 4 rooms and 1 takeable item
 - Players can lose the game due to a bad decision
 - The game is winnable 

### Visualization: 
 - `help` Provides the user a list of commands for your game
 - `look` Re-prints the room description
 - `inventory` prints a list of the items in the players inventory
 -  When the player enters a room they get the room description
  
### Stretch Goals (Requirements first! Then stretch goals.)
- Try changing the console color or adding some beeps for dramatic effect
- Clear the console when appropriate
- The user should know when its their turn try formatting the users input with something like this everytime its the users turn to type
  - What do you do: __________________ // <- Their Answer on the same line
- Add some riddles or puzzles for users to solve to get from room to room
- Lock some doors that users need keys to get through, or incorporate useable objects in some other manner.

