using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Zones
{
    public enum VisibleSetting { All, None, Top };
    public abstract class Zone
    {
        protected static readonly System.Random random = new System.Random();

        protected List<Card> Cards;
        public int Size { get; private set; }
        public VisibleSetting Visibility { get; private set; }
        public int Count { get { return Cards.Count; } }


        public Zone(List<Card> lst, int capacity, VisibleSetting visible)
        {
            if (lst.Count > capacity)
            {
                throw new System.IndexOutOfRangeException($"Cannot initialize Zone of size {capacity} with {lst.Count} cards");
            }
            Cards.AddRange(lst);
            Size = capacity;
            Visibility = visible;
        }

        /* Moves all cards in this Zone to 
         * some other Zone
         */
        public void MoveAll(Zone other)
        {
            foreach (var card in Cards)
            {
                other.Cards.Add(card);
            }
            Cards.Clear();
        }

        //Fisher-Yates random permutation
        public void Shuffle()
        {
            int[] idxs = new int[Cards.Count];
            for (var i = 0; i < Cards.Count; ++i)
            {
                idxs[i] = i;
            }
            for (var i = 0; i < Count - 2; ++i)
            {
                var j = i + random.Next(Count - i);
                var tmp = idxs[i];
                idxs[i] = idxs[j];
                idxs[j] = tmp;

            }
            var NewCards = new List<Card>(Count);

            for (var i = 0; i < Count; ++i)
            {
                NewCards[i] = Cards[idxs[i]];
            }
            Cards = NewCards;
        }
    }

    public class Pile : Zone
    {
        Pile(List<Card> lst, VisibleSetting visible) : base(lst, int.MaxValue, visible) { }

        void Push(Card card)
        {
            Cards.Add(card);
        }

        Card Pop()
        {
            var back = Cards.Count - 1;
            var card = Cards[back];
            Cards.RemoveAt(back);
            return card;
        }

        public List<Card> Draw(int n)
        {
            List<Card> drawn = new List<Card>();
            for(var i = 0; i < n; ++i)
            {
                drawn.Add(Pop());
            }
            return drawn;
        }

    }

    public class Row : Zone
    {
        Row(int capacity) : base(new List<Card> { }, capacity, VisibleSetting.All) {
            for (int i = 0; i < Size; ++i)
            {
                Cards.Add(null);
            }
        }

        // Rows can be indexed into as though they were arrays
        public Card this[int i]
        {
            get
            {
                if (i >= Size)
                {
                    throw new System.IndexOutOfRangeException($"Tried to access element {i} of Row with size {Size}");
                }
                return Cards[i];
            }
            set
            {
                if (i >= Size)
                {
                    throw new System.IndexOutOfRangeException($"Tried to access element {i} of Row with size {Size}");
                }
                Cards[i] = value;
            }
        }

        public void Add(IEnumerable<Card> cards, int start = 0)
        {
            foreach(var card in cards){
                while(Cards[start] != null && start <= Size)
                {
                    ++start;
                }
                if (start >= Size)
                {
                    break;
                }
                Cards[start] = card;
                ++start;
            }
        }
    }
}