using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameResources;

namespace Effects
{
    public class AddResource : Effect
    {
        public ResourceType Kind;

        public int Amount = 1;


        public override void Apply()
        {
            ResourcePool.gPool.Shift(
                Kind, Amount
                );
        }

        public override string ToString()
        {
            return $"+{Amount} {Kind.String()}";
        }
    }
}