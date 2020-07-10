using UnityEngine;
using System.Collections;
using Cards;

namespace Zones
{
    [RequireComponent(typeof(CardDisplay))]
    public class Discard : Stack
    {

        public static Discard gDiscard { get; private set; }
        public CardDisplay CardDisplay;

        public Discard()
        {
            gDiscard = this;
        }


        public void MoveAll()
        {
            while(Cards.Count > 0)
            {
                Move(Cards.Peek());
            }
        }

        // Use this for initialization
        new void Start()
        {
            CardDisplay = GetComponent<CardDisplay>();
            Destination = Deck.gDeck;
            
        }

        protected override bool Add(CardData card)
        {
            CardDisplay.Remove(0);
            CardDisplay.Add(card, 0, this);
            return base.Add(card);
        }

        protected override bool Remove(CardData card)
        {
            var success = base.Remove(card);
            if (success)
            {
                CardDisplay.Remove(0);
            }
            return success;
        }


    }
}