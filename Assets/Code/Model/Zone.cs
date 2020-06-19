using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Zones
{
    public enum VisibleSetting { All, None, Top };
    public abstract class Zone
    {


        protected List<Card> Cards;
        public int Size { get; private set; }
        public VisibleSetting Visibility { get; private set; }


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

    }

    public class Row : Zone
    {
        Row(int capacity) : base(new List<Card> { }, capacity, VisibleSetting.All) { }

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
    }
}