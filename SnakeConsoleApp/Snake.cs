using System.Numerics;

namespace Snake
{
  public class Snake
  {
    // Направление движения змейки.
    public Vector2 Direction;

   
    private List<Vector2> _snake;

    public Snake(Vector2 startStartPosition, Vector2 direction)
    {
      // Задаем значения для поля Direction змейки.
      Direction = direction;

      // Инициализируем массив с сегментами змейки.
      _snake = new List<Vector2>();

      // Добавляем сегемент головы в массив _snake.
      _snake.Add(startStartPosition);
    }

    /// <summary>
    /// Метод добавляет в массив новый сегмент змейки (с координатами, равными последнему сегменту змейки).
    /// </summary>
    public void IncreaseSize()
    {
      _snake.Add(_snake.Last());
    }

    /// <summary>
    /// Метод возвращает длину змейки - размер массива _snake.
    /// </summary>
    public int GetSize()
    {
      return _snake.Count;
    }

    /// <summary>
    /// Метод возвращает координаты сегмента змейки по его индексу в массиве _snake.
    /// </summary>
    public Vector2 GetPoint(int index)
    {
      return _snake[index];
    }


    /// <summary>
    /// Метод меняет направление змейки влево.
    /// </summary>
    public void SetMoveDirectionToLeft()
    {
      Direction = new Vector2(-1, 0);
    }

    /// <summary>
    /// Метод меняет направление змейки вправо.
    /// </summary>
    public void SetMoveDirectionToRight()
    {
      Direction = new Vector2(1,0);
    }

    /// <summary>
    /// Метод меняет направление змейки вверх.
    /// </summary>
    public void SetMoveDirectionToUp()
    {
      Direction = new Vector2(0, -1);
    }

    /// <summary>
    /// Метод меняет направление змейки вниз.
    /// </summary>
    public void SetMoveDirectionToDown()
    {
      Direction = new Vector2(0, 1);
    }

    /// <summary>
    /// Метод передвигает змейку в текущем направлении.
    /// </summary>
    public void MoveForward()
    {
      // Двигаем все сегменты змейки в нужном направлении.
      for (var i = _snake.Count - 1; i > 0; i--)
      {
        // Каждый сегмент занимает положение предыдущего сегмента массива.
        _snake[i] = _snake[i - 1];
      }

      // Голова змейки меняет положение в соответствии с текущим направлением.
      _snake[0] += Direction;
    }
  }
}