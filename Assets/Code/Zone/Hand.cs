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
            Size = HandSize;
            base.Start();
            Destination = Discard.gDiscard;
        }

 
        public void ResetCards()
        {
            for (int i = 0; i < Cards.Count; ++i)
            {
                var c = Cards[i];
                if (c != null)
                {
                    Move(Cards[i]);
                    Display.Remove(i);
                }
            }
            for (int i = 0; i < HandSize; i++)
            {
                Deck.gDeck.Draw();
            }
        }
    }
}