namespace Black_Jack
{
    using Black_Jack.Infrastructure.AbstractClasses;

    public class Dealer : PlayerBase
    {
        public Dealer()
        {
            this.Hand = new Hand(isDealer: true);
        }
    }
}
