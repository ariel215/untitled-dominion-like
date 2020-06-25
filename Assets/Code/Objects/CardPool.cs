using UnityEngine;
using System.Collections.Generic;
using System;
using Cards;

public class CardPool
{

    private List<CardData> Cards;
    Player Player;
    Dictionary<string, GameObject> cardPrefabs;

    public static CardPool Load(string path, Player player)
    {
        throw new NotImplementedException();
    }

    public CardPool(Player p, IEnumerable<CardData> cardsIn)
    {
        Player = p;
        Cards = new List<CardData>(cardsIn);
        Cards.Sort((x, y) => x.MinDamage.CompareTo(y.MinDamage));
    }

    public void AddCards(IEnumerable<CardData> newCards)
    {
        foreach(var card in newCards)
        {
            Cards.Add(card);
        }
        Cards.Sort((x, y) => x.MinDamage.CompareTo(y.MinDamage));

    }

    public CardData Fixed()
    {
        throw new NotImplementedException();
    }

    public List<CardData> Select(int n)
    {
        throw new NotImplementedException();
    }

    void LoadPrefabs()
    {
        foreach(var card in Cards)
        {
            cardPrefabs[card.Name] = Resources.Load<GameObject>(card.Name);
        }
    }

    public GameObject GetObject(CardData card)
    {
        return GameObject.Instantiate(cardPrefabs[card.Name]);
    }

    public GameObject GetObject(string name)
    {
        return GameObject.Instantiate(cardPrefabs[name]);
    }





}
