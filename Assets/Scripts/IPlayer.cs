namespace Assets.Scripts
{
    enum PlayerType
    {
        Bot,
        Real
    }

    public interface IPlayer
    {
        void SetTurnActive();
    }
}