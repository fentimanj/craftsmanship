namespace src;

public class Game
{
    private readonly Board board = new();

    // TODO: Magic Char
    private char lastSymbol = ' ';

    // TODO: Data clump
    // TODO: Primitive Obsession
    // TODO: Long Method
    public void Play(char symbol, int x, int y)
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
        // TODO:  Data clump
        else if (this.IsTileTaken(x, y))
        {
            throw new Exception("Invalid position");
        }

        this.lastSymbol = symbol;
        // TODO: Data clump
        this.board.AddTileAt(symbol, x, y);
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(int x, int y)
    {
        // TODO:  Message Chain
        // TODO: Magic Char
        // TODO: Feature Envy (abstract away .TileAt(x, y).Symbol != ' ')
        return this.board.TileAt(x, y).Symbol != ' ';
    }

    private bool IsInvalidNextPlayer(char symbol)
    {
        return symbol == this.lastSymbol;
    }

    // TODO:  Magic Char
    private static bool IsSymbolNaught(char symbol)
    {
        return symbol == 'O';
    }

    private bool IsFirstMove()
    {
        // TODO:  Magic char
        return this.lastSymbol == ' ';
    }

    // TODO:  Long Method
    public char Winner()
    {
        if (this.IsFirstRowTaken())
        {
            if (this.IsThereSameSymbolInFirstRow())
            {
                // TODO: Message Chain
                // TODO: Feature Envy
                // TODO: Magic Numbers
                return this.board.TileAt(0, 0).Symbol;
            }
        }

        if (this.IsSecondRowTaken())
        {
            if (this.IsThereSameSymbolInSecondRow())
            {
                // TODO: Message Chain
                // TODO: Feature Envy
                // TODO: Magic Numbers
                return this.board.TileAt(1, 0).Symbol;
            }
        }

        if (this.IsThirdRowTaken())
        {
            if (this.IsThereSameSymbolInThirdRow())
            {
                // TODO: Message Chain
                // TODO: Feature Envy
                // TODO: Magic Numbers
                return this.board.TileAt(2, 0).Symbol;
            }
        }

        // TODO: Magic String
        return ' ';
    }

    // TODO: Lots of duplication
    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsThereSameSymbolInThirdRow()
    {
        return this.board.TileAt(2, 0).Symbol ==
               this.board.TileAt(2, 1).Symbol &&
               this.board.TileAt(2, 2).Symbol ==
               this.board.TileAt(2, 1).Symbol;
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsThirdRowTaken()
    {
        return this.board.TileAt(2, 0).Symbol != ' ' &&
               this.board.TileAt(2, 1).Symbol != ' ' &&
               this.board.TileAt(2, 2).Symbol != ' ';
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsThereSameSymbolInSecondRow()
    {
        return this.board.TileAt(1, 0).Symbol ==
               this.board.TileAt(1, 1).Symbol &&
               this.board.TileAt(1, 2).Symbol ==
               this.board.TileAt(1, 1).Symbol;
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsSecondRowTaken()
    {
        return this.board.TileAt(1, 0).Symbol != ' ' &&
               this.board.TileAt(1, 1).Symbol != ' ' &&
               this.board.TileAt(1, 2).Symbol != ' ';
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsThereSameSymbolInFirstRow()
    {
        return this.board.TileAt(0, 0).Symbol ==
               this.board.TileAt(0, 1).Symbol &&
               this.board.TileAt(0, 2).Symbol ==
               this.board.TileAt(0, 1).Symbol;
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    // TODO: Magic Numbers
    private bool IsFirstRowTaken()
    {
        return this.IsTileTaken(0, 0) &&
               this.IsTileTaken(0, 1) &&
               this.IsTileTaken(0, 2);
    }
}