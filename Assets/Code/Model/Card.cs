using UnityEngine;
using System.Collections;
using Effects;

public enum ResourceType { Early, Mid, Late};



public class Card
{

    public ResourceType CostType { get; private set; }
    public int Cost { get; private set; }
    public Effect Effect { get; private set; }

    Card(ResourceType type, int cost, Effect effect)
    {
        CostType = type;
        Cost = cost;
        Effect = effect;
    }
    
}
