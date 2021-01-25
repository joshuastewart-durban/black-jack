namespace Black_Jack.Infrastructure.AbstractClasses
{
    public abstract class PlayerBase
    {
        protected PlayerBase()
        {
        }

        public Hand Hand { get; protected set; }
    }
}
