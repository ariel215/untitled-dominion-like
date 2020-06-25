using UnityEngine;
using System.Collections;

namespace Zones
{
    public class Discard : Stack
    {

        public static Discard gDiscard { get; private set; }
        public Discard()
        {
            gDiscard = this;
        }

        // Use this for initialization
        void Start()
        {
            Destination = Deck.gDeck;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}