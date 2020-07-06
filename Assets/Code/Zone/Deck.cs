using UnityEngine;
using System.Collections.Generic;


namespace Zones
{
    public class Deck : Stack
    {

        public static Deck gDeck { get; private set; }
        System.Random Random;

        
        public Deck()
        {
            gDeck = this;
            Random = new System.Random();
            Destination = Hand.gHand;
        }


        public void Init(IEnumerable<Cards.CardData> cards)
        {
            Cards.Clear();
            foreach (var c in cards)
            {
                Cards.Push(c);
            }
            Shuffle();
        }

        public void Init(CardPool pool)
        {
            Init(pool.Cards);
        }

        //Fisher-Yates random permutation
        public void Shuffle()
        {
            int[] idxs = new int[Cards.Count];
            for (var i = 0; i < Cards.Count; ++i)
            {
                idxs[i] = i;
            }
            for (var i = 0; i < Cards.Count - 2; ++i)
            {
                var j = i + Random.Next(Cards.Count - i);
                var tmp = idxs[i];
                idxs[i] = idxs[j];
                idxs[j] = tmp;

            }

            var NewCards = Cards.ToArray();

            for (var i = 0; i < Cards.Count; ++i)
            {
                var tmp = NewCards[i];
                NewCards[i] = NewCards[idxs[i]];
                NewCards[idxs[i]] = tmp;
            }
            Cards.Clear();
            foreach(var c in NewCards)
            {
                Cards.Push(c);
            }
        }

        public bool Draw()
        {
            if (Cards.Count == 0)
            {
                Discard.gDiscard.MoveAll();
                Shuffle();
            }
            return Move(Cards.Peek());
        }

        // Use this for initialization
        void Start()
        {
            Destination = Hand.gHand;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}