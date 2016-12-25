# HaliteCSharpStarter
A slightly more powerful starter package for Halite in C#

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
