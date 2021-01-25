namespace Black_Jack
{
    using System;
    using Black_Jack.Infrastructure.Constants;
    using Black_Jack.Infrastructure.Enums;
    using Black_Jack.Infrastructure.Interfaces;

    public class Display : IDisplay
    {
        private Game game = new Game();

        private GameConstants gameConstants = new GameConstants();

        public Display(Game game, GameConstants gameConstants)
        {
            this.game = game;
            this.gameConstants = gameConstants;
        }

        public void OnCardDealt()
        {
           this.DisplayPlayerHand();
            switch (this.game.FinalState)
            {
                case GameState.DealerWon:
                case GameState.PlayerWon:
                    this.DisplayDealerHand();
                    break;
                case GameState.Draw:
                    this.DisplayDealerHand();
                    break;
                default:
                    break;
            }
        }

        public void NewGameScreen()
        {
            Console.Clear();
            Console.WriteLine(this.gameConstants.GameDictionary[((int)GameText.WELCOME)]);
            Console.WriteLine(this.gameConstants.GameDictionary[(int)GameText.INFO]);
        }

        public void DisplayDealerHand()
        {
            Console.WriteLine($"{this.gameConstants.GameDictionary[((int)GameText.DEALER_HAND)]} {string.Join(" ", this.game.Dealer.Hand.Cards)}");
            Console.WriteLine($"{this.gameConstants.GameDictionary[((int)GameText.DEALER_TOTAL)]} {this.game.Dealer.Hand.TotalValue}");
            this.DrawLine();
            if (this.game.FinalState == GameState.Draw)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(this.gameConstants.GameDictionary[((int)GameText.DRAW)]);
            }
            else if (this.game.FinalState == GameState.DealerWon || this.game.FinalState == GameState.PlayerWon)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(GameState.PlayerWon == this.game.FinalState ? this.gameConstants.GameDictionary[((int)GameText.PLAYER_WON)]
                    : this.gameConstants.GameDictionary[((int)GameText.DEALER_WON)]);
            }

            Console.ResetColor();
        }

        public void DisplayPlayerHand()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{this.gameConstants.GameDictionary[((int)GameText.PLAYER_HAND)]} {string.Join(" ", this.game.Player.Hand.Cards)}");
            Console.WriteLine($"{this.gameConstants.GameDictionary[((int)GameText.PLAYER_TOTAL)]} {this.game.Player.Hand.TotalValue}");
            this.DrawLine();
        }

        public void DrawLine()
        {
            Console.WriteLine(new string('-', Console.WindowWidth / 2));
        }
    }
}
