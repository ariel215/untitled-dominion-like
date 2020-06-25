using UnityEngine;
using System.Collections;

namespace Zones
{
    public class Hand : Array
    {

        public static Hand gHand;

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
    }
}