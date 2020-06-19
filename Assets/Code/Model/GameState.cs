using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zones;

public class GameState
{
    public Pile deck;
    public Pile discard;
    public Row hand;
    public Row market;

    public Dictionary<ResourceType, int> Resources;
    

    public Player player;
    public Opponent opponent;


}
