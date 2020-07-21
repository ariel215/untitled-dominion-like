using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Cards;

namespace Zones
{
    public abstract class Zone : MonoBehaviour
    {

        public abstract IEnumerable<CardData> GetCards();
        public Zone Destination;
        [SerializeField]
        private int nCards;
        public abstract int Count();

        private void Update()
        {
            nCards = 0;
            foreach (var c in GetCards())
            {
                if (c != null)
                {
                    ++nCards;
                }
            }

        }

        protected abstract bool Add(CardData card);
        protected abstract bool Remove(CardData card);

        protected delegate void SelectAction(CardData card);

        protected List<SelectAction> CardActions = new List<SelectAction>();

        public virtual bool Move(CardData card)
        {
            var removed = Remove(card);
            if (!removed)
            {
                Debug.Log($"Could not remove {card}");
                return false;
            }
            if (Destination == null)
            {
                throw new System.Exception("Destination not set");
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

        public void RegisterCallbacks(
            UnityEvent unityEvent, CardData cardData) {
            foreach (var action in CardActions)
            {
                unityEvent.AddListener(()=>action(cardData));
            }
        }

    }

    

    public abstract class Stack : Zone
    {


        protected Stack<CardData> Cards = new Stack<CardData>();
        public override IEnumerable<CardData> GetCards()
        {
            return Cards;
        }

        public override int Count()
        {
            return Cards.Count;
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

        public override int Count()
        {
            return Cards.Count;
        }

        public override void Start()
        {
            Display = GetComponent<CardDisplay>();
            for (int i = 0; i < Size; ++i)
            {
                Cards.Add(null);
            }
            CardActions.Add((CardData c) => Move(c));
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
                Display.Add(card, idx, this);
                return true;
            }
            return false;

        }

        public bool Move(int idx)
        {
            return Move(Cards[idx]);
        }

        protected override bool Remove(CardData card)
        {
            if (card == null)
            {
                return true;
            }
            var idx = Cards.FindIndex(x => System.Object.ReferenceEquals(x,card));
            if (idx >= 0)
            {
                return Remove(idx);
            }
            return false;
        }

        protected bool Remove(int idx)
        {
            Cards[idx] = null;
            Display.Remove(idx);
            return true;
        }
    }
        
}