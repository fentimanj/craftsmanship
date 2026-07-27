namespace src
{
    public class Tile
    {
        public int X {get; set;}
        public int Y {get; set;}
        public char Symbol {get; set;}
    }

    public class Board
    {
       private readonly List<Tile> tiles = [];
       
        public Board()
        {
            for (int xAxis = 0; xAxis < 3; xAxis++)
            {
                for (int yAxis = 0; yAxis < 3; yAxis++)
                {
                    this.tiles.Add(new Tile{ X = xAxis, Y = yAxis, Symbol = ' '});
                }  
            }       
        }
        
       public Tile TileAt(int x, int y)
       {
           return this.tiles.Single(tile => tile.X == x && tile.Y == y);
       }

       public void AddTileAt(char symbol, int x, int y)
       {
           this.tiles.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
       }
    }

    public class Game
    {
        private char lastSymbol = ' ';
        private readonly Board board = new();
        
        public void Play(char symbol, int x, int y)
        {
            if(this.isFirstMove())
            {
                if(isSymbolNaught(symbol))
                {
                    throw new Exception("Invalid first player");
                }
            } 
            else if (this.IsInvalidNextPlayer(symbol))
            {
                throw new Exception("Invalid next player");
            }
            else if (this.IsTileTaken(x, y))
            {
                throw new Exception("Invalid position");
            }

            this.lastSymbol = symbol;
            this.board.AddTileAt(symbol, x, y);
        }

        private bool IsTileTaken(int x, int y)
        {
            return this.board.TileAt(x, y).Symbol != ' ';
        }

        private bool IsInvalidNextPlayer(char symbol)
        {
            return symbol == this.lastSymbol;
        }

        private static bool isSymbolNaught(char symbol)
        {
            return symbol == 'O';
        }

        private bool isFirstMove()
        {
            return this.lastSymbol == ' ';
        }

        public char Winner()
        {   //if the positions in first row are taken
            if(this.board.TileAt(0, 0).Symbol != ' ' &&
               this.board.TileAt(0, 1).Symbol != ' ' &&
               this.board.TileAt(0, 2).Symbol != ' ')
               {
                    //if first row is full with same symbol
                    if (this.board.TileAt(0, 0).Symbol == 
                        this.board.TileAt(0, 1).Symbol &&
                        this.board.TileAt(0, 2).Symbol == 
                        this.board.TileAt(0, 1).Symbol )
                        {
                            return this.board.TileAt(0, 0).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(this.board.TileAt(1, 0).Symbol != ' ' &&
                this.board.TileAt(1, 1).Symbol != ' ' &&
                this.board.TileAt(1, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (this.board.TileAt(1, 0).Symbol == 
                        this.board.TileAt(1, 1).Symbol &&
                        this.board.TileAt(1, 2).Symbol == 
                        this.board.TileAt(1, 1).Symbol)
                        {
                            return this.board.TileAt(1, 0).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(this.board.TileAt(2, 0).Symbol != ' ' &&
                this.board.TileAt(2, 1).Symbol != ' ' &&
                this.board.TileAt(2, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (this.board.TileAt(2, 0).Symbol == 
                        this.board.TileAt(2, 1).Symbol &&
                        this.board.TileAt(2, 2).Symbol == 
                        this.board.TileAt(2, 1).Symbol)
                        {
                            return this.board.TileAt(2, 0).Symbol;
                        }
                }

            return ' ';
        }
    }
}