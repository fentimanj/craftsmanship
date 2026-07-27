namespace src;

public class Game
{
    private readonly Board board = new();
    private char lastSymbol = ' ';  // TODO: Magic Char

    public void Play(char symbol, int x, int y)  // TODO: Data clump / Primitive Obsession / Long Method
    {
        if (this.IsFirstMove())
        {
            if (IsSymbolNaught(symbol))
            {
                throw new Exception("Invalid first player");
            }
        }
        else if (this.IsInvalidNextPlayer(symbol))
        {
            throw new Exception("Invalid next player");
        }
        else if (this.IsTileTaken(x, y))  // TODO:  Data clump
        {
            throw new Exception("Invalid position");
        }

        this.lastSymbol = symbol;
        this.board.AddTileAt(symbol, x, y); // TODO: Data clump
    }

    private bool IsTileTaken(int x, int y) // TODO:  data clump / primitive obsession
    {
        return this.board.TileAt(x, y).Symbol != ' ';  //TODO:  Message Chain / Magic Char / Feature Envy (abstract away .TileAt(x, y).Symbol != ' ')
    }

    private bool IsInvalidNextPlayer(char symbol)
    {
        return symbol == this.lastSymbol;
    }

    private static bool IsSymbolNaught(char symbol)
    {
        return symbol == 'O';  // TODO:  Magic Char
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == ' '; // TODO:  Magic char
    }

    public char Winner()  // TODO:  Long Method
    {
        if (this.IsFirstRowTaken())
        {
            if (this.IsThereSameSymbolInFirstRow())
            {
                return this.board.TileAt(0, 0).Symbol;  // TODO:  Message Chain / Feature Envy / Magic Numbers
            }
        }

        if (this.IsSecondRowTaken())
        {
            if (this.IsThereSameSymbolInSecondRow())
            {
                return this.board.TileAt(1, 0).Symbol; // TODO:  Message Chain / Feature Envy / Magic Numbers
            }
        }

        if (this.IsThirdRowTaken())
        {
            if (this.IsThereSameSymbolInThirdRow())
            {
                return this.board.TileAt(2, 0).Symbol; // TODO:  Message Chain / Feature Envy / Magic Numbers
            }
        }

        return ' '; // TODO:  Magic String
    }

    // TODO:  Lots of duplication
    private bool IsThereSameSymbolInThirdRow() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.board.TileAt(2, 0).Symbol ==
               this.board.TileAt(2, 1).Symbol &&
               this.board.TileAt(2, 2).Symbol ==
               this.board.TileAt(2, 1).Symbol;
    }

    private bool IsThirdRowTaken() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.board.TileAt(2, 0).Symbol != ' ' &&
               this.board.TileAt(2, 1).Symbol != ' ' &&
               this.board.TileAt(2, 2).Symbol != ' ';
    }

    private bool IsThereSameSymbolInSecondRow() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.board.TileAt(1, 0).Symbol ==
               this.board.TileAt(1, 1).Symbol &&
               this.board.TileAt(1, 2).Symbol ==
               this.board.TileAt(1, 1).Symbol;
    }

    private bool IsSecondRowTaken() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.board.TileAt(1, 0).Symbol != ' ' &&
               this.board.TileAt(1, 1).Symbol != ' ' &&
               this.board.TileAt(1, 2).Symbol != ' ';
    }

    private bool IsThereSameSymbolInFirstRow() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.board.TileAt(0, 0).Symbol ==
               this.board.TileAt(0, 1).Symbol &&
               this.board.TileAt(0, 2).Symbol ==
               this.board.TileAt(0, 1).Symbol;
    }

    private bool IsFirstRowTaken() // TODO:  Message Chain / Feature Envy / Magic Numbers
    {
        return this.IsTileTaken(0,0) &&
               this.IsTileTaken(0,1) &&
               this.IsTileTaken(0,2);
    }
}