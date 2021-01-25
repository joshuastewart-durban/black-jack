namespace Black_Jack
{
    using System;

    public class Card
    {
        public Card(Rank rank, Suite suite)
        {
            this.Rank = rank;
            this.Suite = suite;
        }

        public Rank Rank { get; private set; }

        public Suite Suite { get; private set; }

        public override string ToString()
        {
            char suite = '?';

            switch (this.Suite)
            {
                case Suite.Club:
                    suite = '♣';
                    break;
                case Suite.Diamond:
                    suite = '♦';
                    break;
                case Suite.Heart:
                    suite = '♥';
                    break;
                case Suite.Spades:
                    suite = '♠';
                    break;
            }

            var num = (int)this.Rank > 1 && (int)this.Rank < 11 ? ((int)this.Rank).ToString() : Enum.GetName(typeof(Rank), this.Rank).Substring(0, 1);
            return num + " " + suite;
        }
    }
}
