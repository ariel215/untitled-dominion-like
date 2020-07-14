using Cards;
using System.Collections.Generic;
using UnityEngine;

public class CardPool: MonoBehaviour
{

    public List<CardData> Cards;
    public TextAsset cardNames;

    Player Player;
    Dictionary<string, GameObject> cardPrefabs = new Dictionary<string, GameObject>();

    [SerializeField]
    int Size;

    private void Start()
    {
        Player = Player.Instance;
        Cards = CardData.LoadList(cardNames);
        Size = cardPrefabs.Count;
        Cards.Sort((x, y) => x.CompareMin(y));
    }

    private void Update()
    {
        
    }


    public void AddCards(IEnumerable<CardData> newCards)
    {
        foreach(var card in newCards)
        {
            Cards.Add(card);
        }
        Cards.Sort((x, y) => x.CompareMin(y));

    }

    public List<CardData> Select(int n)
    {
        var health = Player.Health();
        var playable = Cards.FindAll(
            (x => (x.MinDamage() <= health) && (health <= x.MaxDamage()))
            );
        Debug.Log($"Found {playable.Count} playable cards");
        var selected = new List<CardData>();
        for (var i = 0; i < n; i++)
        {
            selected.Add(
                playable[(int)UnityEngine.Random.Range(0, playable.Count)]
                );
            
        }
        return selected;
    }

}
