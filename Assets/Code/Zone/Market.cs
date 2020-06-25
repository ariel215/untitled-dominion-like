using UnityEngine;
using System.Collections;


namespace Zones
{
    public class Market : Array
    {
        public static Market gMarket;

        protected CardPool CardPool;
        public int MarketSize = 4;

        public Market()
        {
            gMarket = this;
        }
        // Use this for initialization
        void Start()
        {
            Destination = Discard.gDiscard;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ResetCards()
        {
            foreach (var card in GetCards())
            {
                Remove(card);
            }

            foreach (var newcard in CardPool.Select(MarketSize))
            {
                Add(newcard);
                Add(CardPool.Fixed());
            }
        }
    }

}