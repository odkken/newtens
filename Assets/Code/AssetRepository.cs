using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using Assets.Code.Games.Tens.Behaviors;

namespace Assets.Code
{
    /// <summary>
    /// Used for accessing prefabs
    /// </summary>
    class AssetRepository
    {
        public ICard GetCard(Definitions.CardRank rank, Definitions.CardSuit suit)
        {
            return new CardBehavior();
        }
    }
}
