namespace src.Services;

using Models;

public sealed class GameOfLife
{
    private Cells seed;

    public GameOfLife(Cells seed)
    {
        this.seed = seed;
    }

    public bool ContinueGenerating()
    {
        return this.seed.HasLivingCells();
    }

    public int GetNumberOfLivingCells()
    {
        return this.seed.GetLivingCells();
    }

    public void CompleteLifecycle()
    {
        this.seed.RemoveCell();
    }
}