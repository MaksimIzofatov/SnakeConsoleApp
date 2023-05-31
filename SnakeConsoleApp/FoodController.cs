using System.Numerics;

namespace Snake
{
  public class FoodController
  {
    public Vector2 Food { get; private set; }// Координаты еды.
    private GameBoard _gameBoard; // Игровое поле.
    private Snake _snake; // Змейка.

    public FoodController(GameBoard gameBoard, Snake snake)
    {
      // Конструктор сохраняет игровое поле и змейку в поля класса.
      _gameBoard = gameBoard;
      _snake = snake;
    }

    public bool IsFoodPickedUp()
    {
      return _snake.GetPoint(0) == Food;
    }
    private bool IsFoodInsideSnake(Snake snake)
    {
      var size = snake.GetSize();

      // Проверяем, совпадает ли позиция еды с позицией хотя бы одной из точек змейки.
      for (var i = 0; i < size; i++)
      {
        // Если совпадает.
        if (snake.GetPoint(i).Equals(Food))
        {
          // Возвращаем true.
          return true;
        }
      }

      // Иначе, возвращаем false.
      return false;
    }


    public void GenerateNewFood()
    {
      // Создаем генератор случайных чисел.
      var randomGenerator = new Random();

      // Метод должен создавать еду на случайной позиции в пределах игрового поля.
      do
      {
        int x = randomGenerator.Next(1, (int)_gameBoard.Size.X);
        int y = randomGenerator.Next(1, (int)_gameBoard.Size.Y);
        Food = new Vector2(x, y);
      }
      while (IsFoodInsideSnake(_snake)); 
    }
  }
}