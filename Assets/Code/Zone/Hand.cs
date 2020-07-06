using UnityEngine;
using System.Collections;

namespace Zones
{
    public class Hand : Array
    {

        public static Hand gHand;
        public static int HandSize = 5;

        public Hand()
        {
            gHand = this;
        }

        // Use this for initialization
        new void Start()
        {
            base.Start();
            Destination = Discard.gDiscard;
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