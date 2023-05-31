namespace Snake
{
  public class GameViewSettings
  {
    // Пустой символ - внутренняя часть игрового поля.
    public char FieldPart = ' ';

    // Символ горизонтальных линий игрового поля (верхняя и нижняя границы).
    public char MapHorizontal = '-';

    // Символ вертикальных линий игрового поля (левая и правая границы).
    public char MapVertical = '|';

    // Символ углов игрового поля (4 угла).
    public char MapCorner = '+';

    public char SnakeHead = '@';
    public char Food = 'X';
    public char SnakeBody = '#';
  }
}