using System.Numerics;

namespace Snake
{
  public class GameOverController
  {
    private GameBoard _gameBoard;
    private Snake _snake;

    /// <summary>
    /// Конструктор объекта GameOverController который сохраняет ссылки на объектs GameBoard b Snake.
    /// </summary>
    public GameOverController(GameBoard gameBoard, Snake snake)
    {
      // Конструктор сохраняет игровое поле и змейку в поля класса.
      _gameBoard = gameBoard;
      _snake = snake;
    }

    /// <summary>
    /// Метод проверяет, ударилась ли змейка о бортики игрового поля.
    /// возвращает True, если змейка ударилась о бортики игрового поля. В остальных случаях возвращает False.
    /// </summary>
    private bool IsSnakeOutside()
    {
      var snakeHead = _snake.GetPoint(0);
      return snakeHead.X == 0 || snakeHead.Y == 0 || snakeHead.X == _gameBoard.Size.X - 1 || snakeHead.Y == _gameBoard.Size.Y - 1;
    }

    /// <summary>
    /// Метод проверяет, ударилась ли змейка сама в себя.
    /// Возвращает True, если змейка врезалась в себя. В остальных случаях возвращает False.
    /// </summary>
    private bool HasSelfCollision()
    {
      var snakeHead = _snake.GetPoint(0);
      for (int i = 1; i < _snake.GetSize(); i++)
      {
        if (snakeHead.Equals(_snake.GetPoint(i)))
          return true;
      }

      return false;
    }

    /// <summary>
    /// Возвращает True, если змейка врезалась в борт игрового поля или в себя. В остальных случаях возвращает False.
    /// </summary>
    public bool CheckGameOver()
    {
      return IsSnakeOutside() || HasSelfCollision();
    }
  }
}