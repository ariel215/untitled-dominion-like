using UnityEngine;
using System.Collections;

namespace Zones
{
    public class Hand : Array
    {

        public static Hand gHand;
        public static int HandSize = 5;

        public int nCards = 0;

        public Hand()
        {
            gHand = this;
            for (int i = 0; i < HandSize; ++i)
            {
                Cards.Add(null);
            }
        }

        // Use this for initialization
        new void Start()
        {
            base.Start();
            Destination = Discard.gDiscard;
        }

        private void Update()
        {
            nCards = Cards.Count;
        }


        void ResetCards()
        {
            foreach(var card in GetCards())
            {
                Move(card);
            }
            for (int i = 0; i < HandSize; i++)
            {
                Deck.gDeck.Draw();
            }
        }
    }
}