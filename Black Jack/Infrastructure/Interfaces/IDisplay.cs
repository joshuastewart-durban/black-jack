namespace Black_Jack.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Black_Jack.Infrastructure.Constants;

    public interface IDisplay
    {
        public void OnCardDealt();

        public void NewGameScreen();

        public void DisplayDealerHand();

        public void DisplayPlayerHand();

        public void DrawLine();
    }
}
