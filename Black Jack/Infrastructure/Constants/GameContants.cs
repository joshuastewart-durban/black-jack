namespace Black_Jack.Infrastructure.Constants
{
    using System.Collections.Generic;
    using Black_Jack.Infrastructure.Enums;

    public class GameConstants
    {
        public GameConstants()
        {
            this.GameDictionary = new Dictionary<int, string>();
            this.GameDictionary.Add((int)GameText.WELCOME, "Welcome to BlackJack 21.");
            this.GameDictionary.Add((int)GameText.INFO, "Press H(Hit), S(Stay) or Enter to start again.");
            this.GameDictionary.Add((int)GameText.PLAYER_HAND, "Player Cards");
            this.GameDictionary.Add((int)GameText.PLAYER_TOTAL, "Player Total:");
            this.GameDictionary.Add((int)GameText.PLAYER_WON, "Player Won!");
            this.GameDictionary.Add((int)GameText.DEALER_HAND, "Dealer Cards");
            this.GameDictionary.Add((int)GameText.DEALER_TOTAL, "Dealer Total:");
            this.GameDictionary.Add((int)GameText.DEALER_WON, "Dealer Won");
            this.GameDictionary.Add((int)GameText.GAME_TITLE, "Blackjack 21");
            this.GameDictionary.Add((int)GameText.DRAW, "Draw");
        }

        public IDictionary<int, string> GameDictionary { get; set; }
    }
}
