namespace src;

using Constant;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = Symbol.Space;

    // TODO: Data clump
    // TODO: Primitive Obsession
    public void Play(char symbol, int x, int y)
    {
        // TODO : Data clump
        this.ValidateMove(symbol, x, y);

        this.lastSymbol = symbol;

        // TODO: Data clump
        this.board.AddTileAt(symbol, x, y);
    }

    private void ValidateMove(char symbol, int x, int y)
    {
        if (this.IsFirstMove() && IsSymbolNaught(symbol))
        {
            {
                throw new Exception("Invalid first player");
            }
        }

        if (this.IsInvalidNextPlayer(symbol))
        {
            throw new Exception("Invalid next player");
        }

        // TODO:  Data clump
        if (this.IsTileTaken(x, y))
        {
            throw new Exception("Invalid position");
        }
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(int x, int y)
    {
        // TODO: Message Chain
        // TODO: Feature Envy (abstract away .TileAt(x, y).Symbol != ' ')
        return this.board.TileAt(x, y).Symbol != Symbol.Space;
    }

    private bool IsInvalidNextPlayer(char symbol)
    {
        return symbol == this.lastSymbol;
    }

    private static bool IsSymbolNaught(char symbol)
    {
        return symbol == Symbol.O;
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == Symbol.Space;
    }

    public char Winner()
    {
        if (this.IsColumnTaken(Column.Left) && this.IsThereSameSymbolInColumn(Column.Left))
        {
            // TODO: Message Chain
            // TODO: Feature Envy
            return this.board.TileAt(Column.Left, Row.Top).Symbol;
        }

        if (this.IsColumnTaken(Column.Center) && this.IsThereSameSymbolInColumn(Column.Center))
        {
            // TODO: Message Chain
            // TODO: Feature Envy
            return this.board.TileAt(Column.Center, Row.Top).Symbol;
        }

        if (this.IsColumnTaken(Column.Right) && this.IsThereSameSymbolInColumn(Column.Right))
        {
            // TODO: Message Chain
            // TODO: Feature Envy
            return this.board.TileAt(Column.Right, Row.Top).Symbol;
        }

        return Symbol.Space;
    }

    // TODO: Message Chain
    // TODO: Feature Envy
    private bool IsThereSameSymbolInColumn(int columnRight)
    {
        return this.board.TileAt(columnRight, Row.Top).Symbol ==
               this.board.TileAt(columnRight, Row.Center).Symbol &&
               this.board.TileAt(columnRight, Row.Bottom).Symbol ==
               this.board.TileAt(columnRight, Row.Center).Symbol;
    }

    
    // TODO: Message Chain
    // TODO: Feature Envy
    private bool IsColumnTaken(int columnLeft)
    {
        return this.IsTileTaken(columnLeft, Row.Top) &&
               this.IsTileTaken(columnLeft, Row.Center) &&
               this.IsTileTaken(columnLeft, Row.Bottom);
    }
}