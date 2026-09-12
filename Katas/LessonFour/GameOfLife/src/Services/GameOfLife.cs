namespace src.Services;

using Models;

public sealed class GameOfLife(Cells cells)
{
    public int GetNumberOfLivingCells()
    {
        return cells.GetLivingCells();
    }

    public void CompleteLifecycle()
    {
        cells.KillCell();
    }
}