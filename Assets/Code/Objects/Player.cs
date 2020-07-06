using System;
using System.Collections.Generic;
using UnityEngine;

public class Player: ScriptableObject
{
    public Dictionary<ResourceType, int> BaseResourceNumber = new Dictionary<ResourceType, int>
    {
        {ResourceType.Early, 0},
        {ResourceType.Mid,0 },
        {ResourceType.Late,0 }
    };

    public int Health
    {
        get
        {
            throw new NotImplementedException();
        }
        set { }
    }
}