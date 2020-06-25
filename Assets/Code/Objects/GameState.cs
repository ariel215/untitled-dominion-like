using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zones;

public class GameState
{
    public static GameState Game { get; private set; } = null;


    public Deck deck;
    public Discard discard;
    public Hand hand;
    public Market market;
    public Zones.Stack cardPool;

    public Dictionary<ResourceType, int> Resources;
    

    public Player player;
    public Opponent opponent;

    public void ResetTurn()
    {
        //Player pitches their hand...
        // and draws a new one

        // Resources reset
        // Market resets

    }

    private void DrawNewHand()
    {
    }
}
