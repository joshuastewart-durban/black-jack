namespace Black_Jack
{
    using System;
    using Black_Jack.Infrastructure.Constants;
    using Black_Jack.Infrastructure.Enums;

    public class Program
    {
        public static void Main(string[] args)
        {
            var constants = new GameConstants();
            Console.Title = constants.GameDictionary[(int)GameText.GAME_TITLE];
            var playGame = true;
            var game = new Game();
            var display = new Display(game, constants);
            display.NewGameScreen();
            game.Play();
            game.Deal();
            display.OnCardDealt();
            while (playGame)
            {
                var command = Console.ReadKey(true).Key;

                switch (command)
                {
                    case ConsoleKey.H:
                        game.Hit();
                        display.OnCardDealt();
                        break;
                    case ConsoleKey.S:
                        game.Stand();
                        display.OnCardDealt();
                        break;
                    case ConsoleKey.Enter:
                        display.NewGameScreen();
                        game.Deal();
                        display.OnCardDealt();
                        break;
                }
            }
        }
    }
}
