namespace Assets.Code.CommonInterfaces
{
    public interface IRound
    {
        IPlayer CurrentTurnPlayer { get; }
        //IPlayer LastTurnPlayer { get; }
        IPlayer Winner { get; }
        bool IsComplete { get; }
        bool IsPlayersTurn(IPlayer player);
        int Score(IPlayer player);
        bool IsPlayable(ICard card);
        void PlayCard(IPlayer player, ICard card);
    }

}
