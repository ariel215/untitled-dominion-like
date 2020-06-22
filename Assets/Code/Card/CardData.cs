using UnityEngine;
using System.Collections;
using Effects;

public enum ResourceType { Early, Mid, Late};


namespace Cards
{
    public class CardData
    {

        public ResourceType CostType { get; private set; }
        public int Cost { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public Effect Effect { get; private set; }


        CardData(ResourceType type, int cost, Effect effect, int min, int max)
        {
            CostType = type;
            Cost = cost;
            Effect = effect;
            MinDamage = min;
            MaxDamage = max;
        }

    }
}
