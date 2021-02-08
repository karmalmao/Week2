using System;
using Raylib_cs;


namespace raylib_test_rn
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GameSettings gs = new GameSettings(800, 450, "Test");
            Raylib.InitWindow(gs.windowWidth, gs.windowHeight, gs.windowTitle);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.SKYBLUE);
                Raylib.EndDrawing();

            }
        }
    }
}
