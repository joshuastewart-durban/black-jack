namespace Black_Jack
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Black_Jack.Infrastructure.AbstractClasses;

    public class Player : PlayerBase
    {
        public Player()
        {
            this.Hand = new Hand(isDealer: false);
        }
    }
}
