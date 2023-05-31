using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace Snake
{
  public class Task
  {
    static void Main(string[] args)
    {
      Console.CursorVisible = false; // Команда для отключения курсора.

      // Создаем контроллеры и все игровые объекты.
      CreateGameViewAndControllers(out var gameController, out var gameView);

      gameView.DrawMap(); // Нарисовали карту.

      while (true)
      {
        // Отрисоваем все игровые объекты.
        gameView.DrawGameObjects();

        Thread.Sleep(200); // Задержка в 200мс.

        var pressedKey = GetPressedKey(); // Получаем нажатую клавишу.

        // Проверяем значение, возвращенное из метода Update.
        if (gameController.Update(pressedKey))
        {
          Console.Clear(); // При проигрыше стираем все игровое поле.
          Console.WriteLine("You lose"); // Выводим сообщение о проигрыше.
                    Console.WriteLine("Do you want to start again? y/n");
          if(Console.ReadKey().Key == ConsoleKey.Y) 
          {
            Console.Clear();
            CreateGameViewAndControllers(out gameController, out gameView);

            gameView.DrawMap();
          }
          else
          {
            break;
          }
                    
        }
      }
    }

    /// <summary>
    /// Метод создает контроллеры и все игровые объекты.
    /// </summary>
    private static void CreateGameViewAndControllers(out GameController gameController, out GameView gameView)
    {
      var gameViewSettings = new GameViewSettings();
      var snake = new Snake(new Vector2(14, 3), new Vector2(1, 0));
      var gameBoard = new GameBoard(30, 8);
      var gameOverController = new GameOverController(gameBoard, snake);
      var inputController = new InputController(snake);
      var foodController = new FoodController(gameBoard, snake);

      foodController.GenerateNewFood(); // Создаем первую еду.

      gameView = new GameView(gameViewSettings, gameBoard, snake, foodController);
      gameController = new GameController(foodController, gameOverController, inputController, snake);
    }

    /// <summary>
    /// Метод получает нажатую клавишу.
    /// </summary>
    private static ConsoleKey GetPressedKey()
    {
      if (Console.KeyAvailable)
      {
        return Console.ReadKey(true).Key;
      }

      return ConsoleKey.NoName;
    }
  }
}