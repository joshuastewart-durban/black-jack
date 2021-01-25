namespace Black_Jack
{
    public interface IDeck
    {
        public void Create();

        public void Shuffle();

        public void Deal(Hand hand);

        public void AdditionalCard(Hand hand);
    }
}
