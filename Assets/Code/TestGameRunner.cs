using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Zones;

[RequireComponent(typeof(Button))]
public class TestGameRunner  : MonoBehaviour
{

    public TextAsset DeckList;

    Button button;

    // Use this for initialization
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPress);
    }


    private void OnPress()
    {
        Deck.gDeck.Init(Cards.CardData.LoadList(DeckList));        
        for (var i = 0; i < Hand.HandSize; ++i)
        {
            Deck.gDeck.Draw();
        }
        Market.gMarket.ResetCards();
    }

    
}
