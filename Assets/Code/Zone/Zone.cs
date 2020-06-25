using UnityEngine;
using System.Collections.Generic;
using Cards;

namespace Zones
{
    public enum VisibleSetting { All, None, Top };
    public abstract class Zone : MonoBehaviour
    {

        public abstract IEnumerable<CardData> GetCards();
        public Zone Destination { get; protected set; }

        protected abstract bool Add(CardData card);
        protected abstract bool Remove(CardData card);

        public bool Move(CardData card)
        {
            return Remove(card) && Destination.Move(card);
        }

    }

    

    public abstract class Stack : Zone
    {

        
        protected Stack<CardData> Cards;
        public override IEnumerable<CardData> GetCards()
        {
            return Cards;
        }

        protected override bool Add(CardData card)
        {
            Cards.Push(card);
            return true;
        }

        protected override bool Remove(CardData card)
        {
            if (card == Cards.Peek())
            {
                Cards.Pop();
                return true;
            }
            return false;
        }

    }

    public abstract class Array : Zone
    {

        List<CardData> Cards;
        public override IEnumerable<CardData> GetCards()
        {
            return Cards;
        }

        protected override bool Add(CardData card)
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

        public bool Add(CardData card, int index)
        {
            if (Cards[index] == null)
            {
                Cards[index] = card;
                return true;
            }
            return false;

        }

        protected override bool Remove(CardData card)
        {
            var idx = Cards.FindIndex(x => x == card);
            if (idx >= 0)
            {
                Cards[idx] = null;
                return true;
            }
            return false;
        }
    }
        
}