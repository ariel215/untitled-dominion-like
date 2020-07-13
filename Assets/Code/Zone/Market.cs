using UnityEngine;


namespace Zones
{
    public class Market : Array
    {
        public static Market gMarket;

        public CardPool RandomCardPool;
        public CardPool FixedCardPool;

        public int MarketSize = 4;



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

        // Update is called once per frame
        void Update()
        {
            
        }

        public void ResetCards()
        {
            for (int i = 0; i < Cards.Count; ++i)
            {
                Cards[i] = null;
                Display.Remove(i);
            }

            Debug.Log(RandomCardPool.Cards.Count);
            foreach (var newcard in RandomCardPool.Select(MarketSize))
            {
                Add(newcard);
            }
            Add(FixedCardPool.Select(1)[0]);
        }
    }

}