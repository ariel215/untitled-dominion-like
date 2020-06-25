using UnityEngine;
using System.Collections.Generic;
using System;
using Cards;

public class CardPool
{

    private List<CardData> cards;
    Player Player;

    public static CardPool Load(string path, Player player)
    {
        throw new NotImplementedException();
    }

    private CardPool(Player p)
    {
        Player = p;
    }

    public CardData Fixed()
    {
        throw new NotImplementedException();
    }

    public List<CardData> Select(int n)
    {
        throw new NotImplementedException();
    }


}
