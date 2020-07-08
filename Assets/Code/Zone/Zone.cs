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
            var removed = Remove(card);
            if (!removed)
            {
                Debug.Log($"Could not remove {card}");
                return false;
            }
            var added = Destination.Add(card);
            if (!added)
            {
                Debug.Log($"Could not add {card}");
            }
            return added;
        }

        public virtual void Start()
        {
            
        }

    }

    

    public abstract class Stack : Zone
    {


        protected Stack<CardData> Cards = new Stack<CardData>();
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

    [RequireComponent(typeof(CardDisplay))]
    public abstract class Array : Zone
    {

        protected List<CardData> Cards = new List<CardData>();
        protected CardDisplay Display;
        protected int Size;

        public override IEnumerable<CardData> GetCards()
        {   
            return Cards;
        }

        public override void Start()
        {
            Debug.Log("Array.Start");
            Display = GetComponent<CardDisplay>();
            for (int i = 0; i < Size; ++i)
            {
                Cards.Add(null);
            }
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

        public bool Add(CardData card, int idx)
        {
            if (Cards[idx] == null)
            {
                Cards[idx] = card;
                Display.Add(card, idx);
                return true;
            }
            return false;

        }

        protected override bool Remove(CardData card)
        {
            if (card == null)
            {
                return true;
            }
            var idx = Cards.FindIndex(x => x == card);
            if (idx >= 0)
            {
                Cards[idx] = null;
                Display.Remove(idx);
                return true;
            }
            return false;
        }
    }
        
}