##Goal 1:  Solve short gun surgery by making Symbol private
    [x] Make Tile.Symbol private
        [x] Use constructor to set Tile.Symbol as symbolAsChar
        [x] Create a getter for Tile.Symbol
        [x] Create a MarkWith method to set Tile.Symbol

##Goal 2A:  Make symbol as an Enum
    []   Tile.cs(11, 13): [CS0246] The type or namespace name 'Symbol' could not be found (are you missing a using directive or an assembly reference?)
        [] Create Symbol Enum
            [] Constructor should take a Symbol enum
                []   Board.cs(15, 41): [CS1503] Argument 1: cannot convert from 'char' to 'src.Symbol'
            [] MarkWith should take a Symbol enum
                []   Board.cs(61, 30): [CS1503] Argument 1: cannot convert from 'char' to 'src.Symbol'
            [] GetSymbol should return a Symbol enum
                []   Board.cs(49, 16): [CS0266] Cannot implicitly convert type 'src.Symbol' to 'char'. An explicit conversion exists (are you missing a cast?)

##Goal 2B: Make Symbol As Enum (using Alex's special method)
    [x] Make Tile.Symbol an Enum 
        [x] Use symbol to char mapper on line 15 of Tile.cs
            [x] Create a Symbol to char mapper
                [x] Create Symbol Enum **
        [x] Use char to symbol mapper on line 11 of Tile.cs 
        [x] Use char to symbol mapper on line 20 of Tile.cs 
            [x] Create a Symbol mapper extension method        
                [x] Create Symbol Enum **
          
##Goal 3:  Remove primitive obsession for for Symbol in Tile.cs
    [x] Remove ToChar from GetSymbol return
    [x] SymbolAt needs a ToChar() on return
    [x] Remove ToSymbol from MarkWith
    [x] Use mapper on symbol in MarkWith() return on AddTileAt