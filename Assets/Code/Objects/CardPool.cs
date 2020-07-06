using UnityEngine;
using System.Collections.Generic;
using System;
using Cards;

public class CardPool: MonoBehaviour
{

    public List<CardData> Cards { get; private set;}    = new List<CardData>();
    public TextAsset cardNames;

    Player Player;
    Dictionary<string, GameObject> cardPrefabs = new Dictionary<string, GameObject>();

    private void Start()
    {
        string[] seps = { "\r", "\n", "\r\n" };
        foreach(var line in cardNames.text.Split(seps, StringSplitOptions.RemoveEmptyEntries))
        {
            var name = line.Trim();
            var data = Resources.Load<CardData>($"Cards/Data/{name}");
            Cards.Add(data);
            name = data.Name();
            cardPrefabs[name] = Resources.Load<GameObject>($"Cards/Prefabs/{name}");
            Debug.Log(cardPrefabs[name]);
        }
        Cards.Sort((x, y) => x.CompareMin(y));
    }


    public void AddCards(IEnumerable<CardData> newCards)
    {
        foreach(var card in newCards)
        {
            Cards.Add(card);
        }
        Cards.Sort((x, y) => x.CompareMin(y));

    }

    public CardData Fixed()
    {
        throw new NotImplementedException();
    }

    public List<CardData> Select(int n)
    {
        var health = Player.Health;
        var playable = Cards.FindAll((x => x.MinDamage() > health));
        playable = playable.FindAll(x => x.MaxDamage() > health);
        var selected = new List<CardData>();
        for (var i = 0; i < n; i++)
        {
            selected.Add(
                playable[(int)UnityEngine.Random.Range(0, playable.Count)]
                );
            
        }
        return selected;
    }

    void LoadPrefabs()
    {
        foreach(var card in Cards)
        {
            cardPrefabs[card.Name()] = Resources.Load<GameObject>(card.Name());
        }
    }

    public GameObject GetObject(CardData card)
    {
        return GameObject.Instantiate(cardPrefabs[card.Name()]);
    }

    public GameObject GetObject(string name)
    {
        return GameObject.Instantiate(cardPrefabs[name]);
    }





}
