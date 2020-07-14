using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class AddResource : Effect
    {
        public GameResources.ResourceType Kind;

        public int Amount;


        public override void Apply()
        {
            GameResources.ResourcePool.gPool.Shift(
                Kind, Amount
                );
        }
    }
}