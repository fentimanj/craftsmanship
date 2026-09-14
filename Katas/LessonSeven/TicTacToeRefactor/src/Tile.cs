namespace src;

using Constant;
//TODO:  Data Class
//TODO:  Primitive Obsession
public class Tile(int column, int row, char symbol, Position? position = null)
{
    
    
    // TODO: Shotgun Surgery
    private int Column { get; set; } = position?.Column ?? column;

    // TODO: Shotgun Surgery
    private int Row { get; set; } = position?.Row ?? row;
    
    private char symbol = symbol;

    public char GetSymbol() => this.symbol;
    public void AddSymbol(char newSymbol)
    {
        if (this.symbol != SymbolOptions.Space)
        {
            throw new Exception("Invalid position");
        }
        this.symbol = newSymbol;
    }
    
    public static Func<Tile, bool> IsAt(int x, int y)
    {
        return tile => tile.Column == x && tile.Row == y;
    }
    
   
}
