using System.Linq;
using Assets.Code.Games.Tens.BotStrategies;

namespace Assets.Code.Games.Tens.Behaviors
{
    class BotTwoPlayerBehavior : TwoPlayerBehavior
    {

        public override void SetTurnActive()
        {



        }

        private void BidWithSimpleStrategy()
        {
            var bidAmount = new SimpleBidStrategy().GetBidAmount(TableHolder.Cards.Concat(HandHolder.Cards).ToList(), CurrentGame.CurrentRound);
            if (bidAmount > CurrentGame.CurrentRound.CurrentBidInfo.Amount)
                CurrentGame.CurrentRound.EnterBid(this, bidAmount);
            else
                CurrentGame.CurrentRound.EnterBid(this, 0);
        }

        private void PlayCardWithSimpleStrategy()
        {
            var cardToPlay = new SimplePlayCardStrategy().PickCardToPlay(this, TableHolder.Cards.Concat(HandHolder.Cards).ToList(), CurrentGame.CurrentRound);
            CurrentGame.CurrentRound.PlayCard(this, TableHolder.Cards.Contains(cardToPlay) ? TableHolder.RemoveCard(cardToPlay) : HandHolder.RemoveCard(cardToPlay));
        }
    }
}