namespace Black_Jack.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IGame
    {
        public void Play();

        public void Deal();

        public void Hit();

        public void Stand();
    }
}
