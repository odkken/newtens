using Assets.Code.CommonBehaviors;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;

namespace Assets.Code
{
    /// <summary>
    /// Used for accessing prefabs
    /// </summary>
    static class AssetRepository
    {
        public static ICard GetCard(Definitions.CardRank rank, Definitions.CardSuit suit)
        {
            return new CardBehavior();
        }
    }
}
