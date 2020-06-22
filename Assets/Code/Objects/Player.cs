using System;
using System.Collections.Generic;

public class Player
{
    public Dictionary<ResourceType, int> BaseResourceNumber = new Dictionary<ResourceType, int>
    {
        {ResourceType.Early, 0},
        {ResourceType.Mid,0 },
        {ResourceType.Late,0 }
    };
}