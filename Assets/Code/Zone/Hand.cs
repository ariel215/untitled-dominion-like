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
        void Start()
        {
            Destination = Discard.gDiscard;
        }

        // Update is called once per frame
        void Update()
        {

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