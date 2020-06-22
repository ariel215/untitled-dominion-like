using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cards;
namespace Zones
{
    public enum VisibleSetting { All, None, Top };
    public abstract class Zone : MonoBehaviour
    {

        public abstract IEnumerable<Card> GetCards();
        public Zone Destination { get; private set; }

        public abstract bool Add(Card card);
    }

    

    public abstract class Stack : Zone
    {

        
        private Stack<Card> Cards;
        public override IEnumerable<Card> GetCards()
        {
            return Cards;
        }

        public override bool Add(Card card)
        {
            Cards.Push(card);
            return true;
        }

        public Card Draw()
        {
            return Cards.Pop();
        }

    }

    public abstract class Array : Zone
    {

        List<Card> Cards;
        public override IEnumerable<Card> GetCards()
        {
            return Cards;
        }

        public override bool Add(Card card)
        {
            for (int i = 0; i < Cards.Count; ++i)
            {
                var added = Add(card, i);
                if (added)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Add(Card card, int index)
        {
            if (Cards[index] == null)
            {
                Cards[index] = card;
                return true;
            }
            return false;

        }
    }
        
}