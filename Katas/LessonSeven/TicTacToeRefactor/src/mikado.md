## Goal 1:  Solve short gun surgery by making Symbol private
    [x] Make Tile.Symbol private
        [x] Use constructor to set Tile.Symbol as symbolAsChar
        [x] Create a getter for Tile.Symbol
        [x] Create a MarkWith method to set Tile.Symbol

## Goal 2A:  Make symbol as an Enum
    []   Tile.cs(11, 13): [CS0246] The type or namespace name 'Symbol' could not be found (are you missing a using directive or an assembly reference?)
        [] Create Symbol Enum
            [] Constructor should take a Symbol enum
                []   Board.cs(15, 41): [CS1503] Argument 1: cannot convert from 'char' to 'src.Symbol'
            [] MarkWith should take a Symbol enum
                []   Board.cs(61, 30): [CS1503] Argument 1: cannot convert from 'char' to 'src.Symbol'
            [] GetSymbol should return a Symbol enum
                []   Board.cs(49, 16): [CS0266] Cannot implicitly convert type 'src.Symbol' to 'char'. An explicit conversion exists (are you missing a cast?)

## Goal 2B: Make Symbol As Enum (using Alex's special method)
    [x] Make Tile.Symbol an Enum 
        [x] Use symbol to char mapper on line 15 of Tile.cs
            [x] Create a Symbol to char mapper
                [x] Create Symbol Enum **
        [x] Use char to symbol mapper on line 11 of Tile.cs 
        [x] Use char to symbol mapper on line 20 of Tile.cs 
            [x] Create a Symbol mapper extension method        
                [x] Create Symbol Enum **
          
## Goal 3:  Remove primitive obsession for Symbol from code
    [] Introduce a new Play method in Game.cs that takes a Symbol enum
        [x]  Invoke mapper to symbol for PlayNew
        [x]  Game.ValidateMove needs to accept a Symbol enum
            [x] Game.IsSymbolNaught should take a Symbol enum
                [x] Use Symbol.O instead as SymbolAsChar on return
            [x] Game.IsInvalidNextPlayer should take a Symbol enum
                [x] lastSymbol needs to be Enum on the return
                    [x] Change symbol as char to Symbol enum
        [x]  board.AddTileAt needs to take in a symbol
            [x] MarkWith needs to take in a Symbol
               
## Goal 4 : X is private
    [x] Make X Private in Tile.cs
        [x] Move X to constructor of Tile.cs
## Goal 5 : Y is private
    [x] Make Y Private in Tile.cs
        [x] Move Y to constructor of Tile.cs
## Goal 6: Replace X and Y with a Position enum 
    [x] Change AddTileAt to accept a Position enum
    [x] Change IsTileTaken to accept a Position enum
    [x] ColumnTakenBy needs to use a PositionMapper to convert xy to position
            [x] SymbolAt needs to accept a position
                [x] Change IsAt to accept a Position enum
                    [x] Tile needs a positions property
                        [x] We need to build a Position mapper to convert xy to position
                        [x] Create a positions enum
    [x] Tile should take in Position in ctor
        [x] Board ctor should iterate through enum values and populate 3x3 grid with space
## Goal 7:  Remove primitive obsession from Tile
    [x] Change ctor to Symbol
        [x]Fix Board ctor


## Goal 7:  Replace X & Y with a Coordinate class (convert Row and Column into enums)
