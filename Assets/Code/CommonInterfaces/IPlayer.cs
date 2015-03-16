namespace Assets.Code.CommonInterfaces
{
    public interface IPlayer
    {
        void SetTurnActive();
        void GiveCard(ICard card);
    }
}
