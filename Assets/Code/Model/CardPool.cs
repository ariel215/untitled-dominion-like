using UnityEngine;
using System.Collections.Generic;
using System;
public class CardPool
{

    private List<Card> cards;
    Player Player;

    public static CardPool Load(string path, Player player)
    {
        throw new NotImplementedException();
    }

    private CardPool(Player p)
    {
        Player = p;
    }
}
