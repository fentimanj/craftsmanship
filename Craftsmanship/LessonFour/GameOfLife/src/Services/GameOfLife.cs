namespace src.Services;

using Models;

public sealed class GameOfLife
{
    private readonly SeedingCells seed;

    public GameOfLife(SeedingCells seed)
    {
        this.seed = seed;
    }

    public bool ContinueGenerating()
    {
        return this.seed.HasLivingCells();
    }
}