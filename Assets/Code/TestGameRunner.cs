using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Zones;

[RequireComponent(typeof(Button))]
public class TestGameRunner  : MonoBehaviour
{

    public CardPool CardPool;

    Button button;

    // Use this for initialization
    private void Start()
    {
        button = GetComponent<Button>();
        Debug.Log(button);
        button.onClick.AddListener(OnPress);
    }


    private void OnPress()
    {
        button = GetComponent<Button>();
        Deck.gDeck.Init(CardPool);
        var deckcards = new List<Cards.CardData>(Deck.gDeck.GetCards());
        Debug.Log(
            Deck.gDeck.Draw()
            );
    }

    
}
