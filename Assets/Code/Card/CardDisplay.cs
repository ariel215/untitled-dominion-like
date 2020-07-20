using UnityEngine;
using System.Collections.Generic;

using Cards;

/// <summary>
/// Component that knows how to render a list of cards
/// centered on the attatched GameObject
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class CardDisplay : MonoBehaviour
{
    // Cache of card prefabs
    private static Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();

    public Vector2 LeftEdge;
    float CardSize;
    public int NCards;
    public GameObject CardTemplate;

    SpriteRenderer background;

    // List of cards being rendered
    public List<GameObject> CardObjects = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        background = GetComponent<SpriteRenderer>();
        LeftEdge = new Vector2(background.bounds.min.x, background.bounds.center.y);
        var width = background.bounds.max.x - background.bounds.min.x;
        CardSize = width / NCards;
        LeftEdge.x += CardSize / 2;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        for (int i = 0; i < CardObjects.Count; ++i)
        {
            var pos = new Vector2(LeftEdge.x, LeftEdge.y);
            pos.x += i * CardSize;
            if (CardObjects[i] != null)
            {
                CardObjects[i].transform.position = pos;
            }
        }
    }

    public void Add(CardData cardData, int idx, Zones.Zone owner)
    {
        // Resize list to hold up to the given index
        if (idx >= CardObjects.Count)
        {
            while (CardObjects.Count <= idx)
            {
                CardObjects.Add(null);
            }
        }

        GameObject card = GetPrefab(cardData);
        
        CardObjects[idx] = card;
        var button = card.GetComponent<ButtonLike>();
        owner.RegisterCallbacks(button.OnClick, cardData);

    }

    private GameObject GetPrefab(CardData cardData)
    {
        var name = cardData.name;
        
        // Initialize cache if necessary
        if (!Prefabs.ContainsKey(name))
        {
            GameObject template = Instantiate(CardTemplate);
            template.SetActive(false);
            template.GetComponent<CardTemplate>().Init(cardData);
            Prefabs[name] = template;
;
        }

        var fab = Instantiate(Prefabs[name]);
        fab.SetActive(true);
        return fab;
    }


    public void Remove(int idx)
    {
        if (idx < CardObjects.Count)
        {
            var obj = CardObjects[idx];
            CardObjects[idx] = null;
            Destroy(obj);
        }

    }


    
}
