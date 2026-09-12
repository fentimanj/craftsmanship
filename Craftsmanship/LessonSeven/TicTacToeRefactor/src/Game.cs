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
    // TODO:  Feature Envy
    private bool IsTileTaken(int x, int y)
    {
        var symbol = this.board.SymbolAt(x, y);
        return symbol != Symbol.Space;
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
        //TODO:  Feature Envy
        if (this.IsColumnTaken(Column.Left) && this.IsThereSameSymbolInColumn(Column.Left))
        {
            return this.board.SymbolAt(Column.Left, Row.Top);
        }

        //TODO:  Feature Envy
        if (this.IsColumnTaken(Column.Center) && this.IsThereSameSymbolInColumn(Column.Center))
        {
            return this.board.SymbolAt(Column.Center, Row.Top);
        }

        //TODO:  Feature Envy
        if (this.IsColumnTaken(Column.Right) && this.IsThereSameSymbolInColumn(Column.Right))
        {
            return this.board.SymbolAt(Column.Right, Row.Top);
        }

        return Symbol.Space;
    }

    private bool IsThereSameSymbolInColumn(int columnRight)
    {
        //TODO:  Feature Envy
        return this.board.SymbolAt(columnRight, Row.Top) ==
               this.board.SymbolAt(columnRight, Row.Center) &&
               this.board.SymbolAt(columnRight, Row.Bottom) ==
               this.board.SymbolAt(columnRight, Row.Center);
    }

    private bool IsColumnTaken(int columnLeft)
    {
        //TODO:  Feature Envy
        return this.IsTileTaken(columnLeft, Row.Top) &&
               this.IsTileTaken(columnLeft, Row.Center) &&
               this.IsTileTaken(columnLeft, Row.Bottom);
    }
}