namespace Assets.Code.CommonInterfaces
{
    interface IRound
    {
        IPlayer CurrentTurnPlayer { get; }
        //IPlayer LastTurnPlayer { get; }
        IPlayer Winner { get; }
        bool IsComplete { get; }
        bool IsPlayersTurn(IPlayer player);
        int Score(IPlayer player);
        void PlayCard(IPlayer player, ICard card);
    }

}
