# HaliteCSharpStarter
A slightly more powerful starter package for Halite in C# based on the original community package.

To use, download the Halite executable form https://halite.io/downloads.php and execute `runGame.bat`.

The package contains a basic random bot as the player and a random bot as the opponent (RandomBot.cs).

## Important bits
### MyBot.cs
This is the main entry point for the app. Data is read from Console.in and translated into a map of sites corresponding to the playing grid.

`Networking.GetFrame(map);` updates the sites in the map to take into account moves from the previous turn. Place your logic for movement after this line and build up a list of `moves` for your sites here. This list is then passed onto the Halite app using `Networking.SendMoves(moves);`
 
### Map.cs
This is the map corresponding to the playing grid. It consists of an x by y array of `Site`s. The `Site`s can be accessed in `MyBot.cs` using `map[x,y]` to get the site at the desired co-ordinate. The `x` and `y` arguments can be greater than the width/height of the map and will automatically be wrapped to the correct block.

A useful method exposed by the `map` is `map.GetMySites()` which returns a list of sites of which you are the owner.

### Site.cs
This corresponds to a single block on the map grid. It has the following properties:

* Owner [int]
* Strength [int]
* Production [int]
* X [int]
* Y [int]
* Top [Site]
* Bottom [Site]
* Left [Site]
* Right [Site]

`Site` also exposes the following methods:
* GetDirectionToNeighbour(Site neighbour) [Direction]
* IsMine() [bool]
* IsEnemy() [bool]
* IsEmpty() [bool]

### Config.cs
This is a singleton which exposes the following properties:
* PlayerTag [int] - your player tag assigned by the Halite runner
* MapWidth [int] - the width of the playing grid
* MapHeight [int] - the height of the playing grid
* Turn [int] - the current turn

## Using the Visual Studio Debugger
If you would like to use the powerful, built in VS debugger to debug your code then this is one of the many solutions but it's the one I prefer and use most.

1. Add a reference `using System.Diagnostics;` in MyBot.cs
2. At the beginning of the main method in MyBot.cs, add the following line: `while(!Debugger.IsAttached);`
3. Add a `-t` flag at the end of the execution of the simulation in runGame.bat to disable the timeout.
4. Run the simulation. At this point the simulation should freeze on the initialisation of the bot.
5. Ensure that you have set a break point somewhere in your code.
6. In Visual Studio, in the toolbar click on `Debug>Attach to Process` and select MyBot.exe from the list
7. Debug to your heart's desire.