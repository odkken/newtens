using System.Collections.Generic;
using Assets.Scripts.Cards;

namespace Assets.Scripts
{
    public interface IGameRules
    {
        void StartGame(IEnumerable<Player> players);

        bool CanBePlayed(Card card);

        void PlayCard(Card card);

        Player CurrentTurnPlayer();

        void SeatPlayer(Player player);

        void DealNextCard(Card card);

    }
}
