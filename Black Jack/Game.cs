namespace Black_Jack
{
    using System;
    using Black_Jack.Infrastructure.Constants;
    using Black_Jack.Infrastructure.Exceptions;
    using Black_Jack.Infrastructure.Interfaces;

    public class Game : IGame
    {
        private Deck deck;

        public Game()
        {
            this.Dealer = new Dealer();
            this.Player = new Player();
            this.FinalState = GameState.Fresh;
            this.Actions = GameAction.None;
        }

        public GameAction Actions { get; set; }

        public GameState FinalState { get; set; }

        public Player Player { get; private set; }

        public Dealer Dealer { get; private set; }

        public void Deal()
        {
            try
            {
                if ((this.Actions & GameAction.Deal) != GameAction.Deal)
                {
                    throw new BlackJackException(Errors.NotAllowedAction, new InvalidOperationException());
                }

                this.FinalState = GameState.Fresh;

                if (this.deck == null)
                {
                    this.deck = new Deck();
                }
                else
                {
                    this.deck.Create();
                }

                this.deck.Shuffle();
                this.Dealer.Hand.Clear();
                this.Player.Hand.Clear();

                this.deck.Deal(this.Dealer.Hand);
                this.deck.Deal(this.Player.Hand);

                if (this.Player.Hand.SoftValue == 21)
                {
                    if (this.Dealer.Hand.SoftValue == 21)
                    {
                        this.FinalState = GameState.Draw;
                    }
                    else
                    {
                        this.FinalState = GameState.PlayerWon;
                    }

                    this.Actions = GameAction.Deal;
                }
                else if (this.Dealer.Hand.TotalValue == 21)
                {
                    this.FinalState = GameState.DealerWon;
                    this.Actions = GameAction.Deal;
                }
                else
                {
                    this.Actions = GameAction.Hit | GameAction.Stand;
                }
            }
            catch (Exception)
            {
            }
        }

        public void Hit()
        {
            try
            {
                if ((this.Actions & GameAction.Hit) != GameAction.Hit)
                {
                    throw new BlackJackException(Errors.EndOfRound, new InvalidOperationException());
                }

                this.deck.AdditionalCard(this.Player.Hand);

                if (this.Player.Hand.TotalValue > 21)
                {
                    this.FinalState = GameState.DealerWon;
                    this.Actions = GameAction.Deal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Play()
        {
            this.Actions = GameAction.Deal;
        }

        public void Stand()
        {
            try
            {
                if ((this.Actions & GameAction.Stand) != GameAction.Stand)
                {
                    throw new BlackJackException(Errors.EndOfRound, new InvalidOperationException());
                }

                while (this.Dealer.Hand.SoftValue < 17)
                {
                    this.deck.AdditionalCard(this.Dealer.Hand);
                }

                if (this.Dealer.Hand.TotalValue > 21 || this.Player.Hand.TotalValue > this.Dealer.Hand.TotalValue)
                {
                    this.FinalState = GameState.PlayerWon;
                }
                else if (this.Dealer.Hand.TotalValue == this.Player.Hand.TotalValue)
                {
                    this.FinalState = GameState.Draw;
                }
                else
                {
                    this.FinalState = GameState.DealerWon;
                }

                this.Actions = GameAction.Deal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
