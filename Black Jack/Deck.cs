namespace Black_Jack
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Deck : IDeck
    {
        private readonly List<Card> cards = new List<Card>(52);

        public Deck()
        {
            this.Create();
        }

        internal ReadOnlyCollection<Card> Cards
        {
            get { return this.cards.AsReadOnly(); }
        }

        public void Deal(Hand hand)
        {
            if (this.cards.Count < 2)
            {
                throw new InvalidOperationException();
            }

            var card = this.cards.First();
            hand.AddCard(card);
            this.cards.Remove(card);

            card = this.cards.First();

            hand.AddCard(card);
            this.cards.Remove(card);
        }

        public void AdditionalCard(Hand hand)
        {
            if (this.cards.Count < 1)
            {
                throw new InvalidOperationException();
            }

            hand.AddCard(this.cards.First());
            this.cards.RemoveAt(0);
        }

        public void Create()
        {
            this.cards.Clear();
            for (var i = 1; i <= 4; i++)
            {
                for (var k = 1; k <= 13; k++)
                {
                    this.cards.Add(new Card((Rank)k, (Suite)i));
                }
            }
        }

        public void Shuffle()
        {
            if (this.cards.Count < 52)
            {
                throw new InvalidOperationException();
            }

            var emptyDeck = new List<Card>();
            var random = new Random();
            int randomNumber;
            for (var i = 0; i < 52; i++)
            {
                randomNumber = random.Next(this.cards.Count);
                emptyDeck.Add(this.cards[randomNumber]);
                this.cards.RemoveAt(randomNumber);
            }

            for (int i = 0; i < 52; i++)
            {
                this.cards.Add(emptyDeck[i]);
            }
        }
    }
}
