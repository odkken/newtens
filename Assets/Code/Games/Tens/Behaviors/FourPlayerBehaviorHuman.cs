using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.Behaviors
{
    class FourPlayerBehaviorHuman : BasePlayerBehavior
    {
        public FourPlayerBehaviorHuman()
        {
        }

        public override void SetTurnActive()
        {
        }

        public override void GiveCard(ICard card)
        {
            HandHolder.AddCard(card);
        }
    }
}
