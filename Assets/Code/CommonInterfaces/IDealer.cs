namespace Assets.Code.CommonInterfaces
{
    interface IDealer
    {
        void DealNextCard(IDeck deck);
        void DealAllCards(IDeck deck);
    }
}