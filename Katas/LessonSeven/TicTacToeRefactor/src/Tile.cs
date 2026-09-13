namespace src;

using Constant;

//TODO:  Primitive Obsession
public class Tile(int x, int y, char symbol)
{
    // TODO: Shotgun Surgery
    public int X { get; set; } = x;

    // TODO: Shotgun Surgery
    public int Y { get; set; } = y;
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
        return tile => tile.X == x && tile.Y == y;
    }
    
   
}
