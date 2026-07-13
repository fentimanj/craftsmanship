namespace src.Services;

using Enums;

public class TicTacToe
{
    public TicTacToe()
    {
        this.moves = new Moves();
    }
    private Symbol currentSymbol = Symbol.X;
    private int numberOfMoves = 0;
    private Moves moves;
    
    public Symbol CurrentSymbol()
    {
        return this.currentSymbol;
    }

    public void TakeTurn(Column columnIndex, Row rowIndex)
    {
        this.numberOfMoves++;
        this.moves.AddMove(columnIndex);
        
        if (this.currentSymbol == Symbol.X)
        {
            this.currentSymbol = Symbol.O;
            return;
        }

        this.currentSymbol = Symbol.X;
    }

    public Symbol GetWinningSymbnol()
    {
        return this.moves.WinningSymbol();
    }
}

internal class Moves
{
    private List<Column> columns = new List<Column>();

    public void AddMove(Column column)
    {
        this.columns.Add(column);
    }

    public Symbol WinningSymbol()
    {
        if (this.columns.Count == 5)
        {
            return Symbol.X;
        }
        
        return Symbol.Unknown;
    }
}