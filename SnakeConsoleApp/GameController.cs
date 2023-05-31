namespace Snake
{
  /// <summary>
  /// Класс, отвечающий за процесс игры.
  /// </summary>
  public class GameController
  {
    private FoodController _foodController;
    private GameOverController _gameOverController;
    private InputController _inputController;
    private Snake _snake;

    /// <summary>
    /// Конструктор объекта GameController, который сохраняет ссылки на объекты классов:
    /// FoodController, GameOverController, InputController, Snake.
    /// </summary>
    public GameController(FoodController foodController, GameOverController gameOverController,
        InputController inputController, Snake snake)
    {
      // Конструктор сохраняет игровые контроллеры в поля класса.
      _foodController = foodController;
      _gameOverController = gameOverController;
      _inputController = inputController;
      _snake = snake;
    }

    /// <summary>
    /// Метод содержит в себе всю игровую механику:
    /// 1)Проверяет, проиграл ли игрок
    /// 2)Проверяет, подобрала змейку еду, если подобрала генерирует новую.
    /// 3)Меняет направление змейки при нажатой кнопке, иначе двигает змейку в том же направлении.
    /// Возвращает True если игрок проиграл, иначе False
    /// </summary>
    public bool Update(ConsoleKey consoleKey)
    {
      // Если игрок проиграл - возвращаем true.
      if (_gameOverController.CheckGameOver())
      {
        return true;
      }
      // Если змейка подобрала еду - увеличиваем размер змейки и генерируем новую еду.
      if (_foodController.IsFoodPickedUp())
      {
        _snake.IncreaseSize();
        _foodController.GenerateNewFood();
      }

      // Если нажата кнопка на клавиатуре (нажатая клавиша не равна ConsoleKey.NoName) - меняем направление змейке.
      if (consoleKey != ConsoleKey.NoName)
      {
        _inputController.ProcessInput(consoleKey);
      }
      else
      {
        // Иначе, двигаем змейку в прежнем направлении.
        _inputController.MoveSnake();
      }

      // Возвращаем false. До этой строки дойдем в случае, если игрок не проиграл.
      return false;
    }
  }
}