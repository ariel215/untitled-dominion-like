using UnityEngine;
using System.Collections.Generic;


namespace Zones
{
    public class Market : Array
    {
        public static Market gMarket;

        public CardPool RandomCardPool;
        public CardPool FixedCardPool;

        public int MarketSize = 4;

        [SerializeField]
        private List<Cards.CardData> cards = new List<Cards.CardData>();


        public Market()
        {
            gMarket = this;
        }
        // Use this for initialization
        public override void Start ()
        {
            if (gMarket is null)
            {
                throw new System.Exception("global market is null");
            }

            Size = MarketSize + 1;
            base.Start();
            Destination = Discard.gDiscard;
            RandomCardPool = GameRunner.Runner.RandomPool;
            FixedCardPool = GameRunner.Runner.FixedPool;
        }

        private void Update()
        {
            cards.Clear();
            cards.AddRange(GetCards());
        }

        public static bool CanBuy(Cards.CardData card)
        {
            var pool = GameResources.ResourcePool.gPool;
            var type = card.CostType();
            var available = pool.Resources[type];
            return (available >= card.Cost());
        }

        public override bool Move(Cards.CardData card)
        {
            if (CanBuy(card))
            {
                GameResources.ResourcePool.gPool.Shift(
                    card.CostType(), -card.Cost()
                    );
                return base.Move(card);
                
            }
            else
            {
                return false;
            }
        }


        public void ResetCards()
        {
            for (int i = 0; i < Cards.Count; ++i)
            {
                Cards[i] = null;
                Display.Remove(i);
            }

            foreach (var newcard in RandomCardPool.Select(MarketSize))
            {
                Add(newcard);
            }

            Add(FixedCardPool.Select(1)[0]);
        }
    }

}