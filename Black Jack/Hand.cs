namespace Black_Jack
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Hand : IHand
    {
        private readonly List<Card> cards = new List<Card>(5);

        public Hand(bool isDealer = false)
        {
            this.IsDealer = isDealer;
        }

        public bool IsDealer { get; private set; }

        public ReadOnlyCollection<Card> Cards
        {
            get { return this.cards.AsReadOnly(); }
        }

        public int SoftValue
        {
            get { return this.cards.Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum(); }
        }

        public int TotalValue
        {
            get
            {
                var totalValue = this.SoftValue;
                var aces = this.cards.Count(c => c.Rank == Rank.Ace);

                while (aces-- > 0 && totalValue > 21)
                {
                    totalValue -= 9;
                }

                return totalValue;
            }
        }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public void Clear()
        {
            this.cards.Clear();
        }
    }
}
