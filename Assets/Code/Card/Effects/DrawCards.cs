using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zones;
namespace Effects
{
    public class DrawCards : Effect
    {

        public int Num = 1;

        public override void Apply()
        {
            for (int i = 0; i < Num; ++i)
            {
                Deck.gDeck.Draw();
            }
        }

        public override string ToString()
        {
            return $"+{Num} Cards";
        }
    }

}