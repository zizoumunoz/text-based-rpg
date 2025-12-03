using Raylib_cs;
using VGP133_Final_Assignment.Core;

namespace HelloWorld;

public static class Program
{
    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(1920, 1080, "Hello World");

        Game game = new Game();
        game.Run();

        Raylib.CloseWindow();
    }
}
