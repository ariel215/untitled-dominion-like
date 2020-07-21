using UnityEngine;
using System.Collections;
using Zones;

public class GameRunner  : MonoBehaviour
{

    public TextAsset TestDeckList;

    public CardPool RandomPool;
    public CardPool FixedPool;

    public static GameRunner Runner;

    GameRunner()
    {
        if (Runner == null)
        {
            Runner = this;
        }
    }

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(Init());
    }

    public IEnumerator Init()
    {
        yield return null;
        Deck.gDeck.Init(Cards.CardData.LoadList(TestDeckList));
        yield return null;
        NextTurn();
    }


    public void NextTurn()
    {
        Hand.gHand.ResetCards();
        Market.gMarket.ResetCards();
        GameResources.ResourcePool.gPool.Reset();
    }

    
}
