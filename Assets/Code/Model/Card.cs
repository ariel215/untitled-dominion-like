using UnityEngine;
using System.Collections;
using Effects;

public enum ResourceType { Early, Mid, Late};

public class Card
{

    public ResourceType CostType { get; private set; }
    public int Cost { get; private set; }
    public Effect Effect { get; private set; }

    int MinDamage, MaxDamage;

    Card(ResourceType type, int cost, Effect effect, int min, int max)
    {
        CostType = type;
        Cost = cost;
        Effect = effect;
        MinDamage = min;
        MaxDamage = max;
    }
    
}   
