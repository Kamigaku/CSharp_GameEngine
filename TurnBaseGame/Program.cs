using System;
using TurnBaseGame.Logging;
using TurnBaseGame.Screens;

#if WINDOWS || LINUX
/// <summary>
/// The main class.
/// </summary>
namespace TurnBaseGame
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Log(Logger.LogLevel.DEBUG, "Beginning of the graphic application");
            using (var game = new LevelScreen())
                game.Run();
        }
    }
}
#endif
