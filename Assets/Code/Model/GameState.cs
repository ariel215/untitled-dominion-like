using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zones;

public class GameState
{
    public static GameState Game { get; private set; } = null;


    public Pile deck;
    public Pile discard;
    public Row hand;
    public Row market;
    public Pile cardPool;

    public Dictionary<ResourceType, int> Resources;
    

    public Player player;
    public Opponent opponent;

    public void ResetTurn()
    {
        //Player pitches their hand...
        hand.MoveAll(discard);
        // and draws a new one
        DrawNewHand();

        // Resources reset
        foreach (var kind in Resources.Keys)
        {
            Resources[kind] = player.BaseResourceNumber[kind];
        }
        // Market resets
        market.Add(cardPool.Draw);

    }

    private void DrawNewHand()
    {
        List<Card> newHand;
        if (deck.Count > hand.Size)
        {
            newHand = deck.Draw(hand.Size);
        }
        else
        {
            newHand = deck.Draw(deck.Count);
            var remaining = hand.Size - hand.Count;
            discard.MoveAll(deck);
            deck.Shuffle();
            newHand.AddRange(deck.Draw(remaining));
        }
        hand.Add(newHand);
    }
}
