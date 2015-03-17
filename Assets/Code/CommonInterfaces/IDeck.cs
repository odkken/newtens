namespace Assets.Code.CommonInterfaces
{
    interface IDeck
    {
        ICard RemoveTopCard();
        void Shuffle(int seed);
        int NumCardsLeft { get; }
    }
}
