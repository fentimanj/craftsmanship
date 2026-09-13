namespace src;

using System.Drawing;
using Constant;

// TODO: Data Class
public class Tile
{
    public Tile(int x, int y, char symbol)
    {
        this.X = x;
        this.Y = y;
        this.symbol = symbol;
    }
    // TODO: Shotgun Surgery
    public int X { get; set; }

    // TODO: Shotgun Surgery
    public int Y { get; set; }
    private char symbol;

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
        return tile => tile.X == x && tile.Y == y;
    }
    
   
}
