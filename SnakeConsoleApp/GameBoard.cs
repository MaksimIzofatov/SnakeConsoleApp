using System.Numerics;

namespace Snake
{
  public class GameBoard
  {
    public Vector2 Size { get; private set; }

    public GameBoard(int x, int y)
    {
      Size = new Vector2(x, y);
    }
  }
}