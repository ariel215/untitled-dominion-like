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
    public float CardSize;
    public float MarginSize;
    SpriteRenderer renderer;

    // List of cards being rendered
    public List<GameObject> CardObjects = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        LeftEdge = transform.position;
        LeftEdge.x -= renderer.bounds.extents.x;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        for (int i = 0; i < CardObjects.Count; ++i)
        {
            var pos = new Vector2(LeftEdge.x, LeftEdge.y);
            pos.x += i * 2 * (MarginSize + CardSize);
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
        
        
        var name = cardData.Name();

        // Initialize cache if necessary
        if (!Prefabs.ContainsKey(name))
        {
            var fab = Resources.Load<GameObject>($"Cards/Prefabs/{name}");
            Prefabs[name] = fab ?? throw new System.Exception($"Could not find prefab {name}")
;
        }

        var card = Instantiate(Prefabs[name]);
        // take the opportunity to initialize card size
        if (CardSize == 0)
        {
            var renderer = card.GetComponent<SpriteRenderer>();
            CardSize = renderer.bounds.extents.x;
            LeftEdge.x += CardSize + MarginSize;
        }
        CardObjects[idx] = card;
        var button = card.GetComponent<ButtonLike>();
        button.OnClick.AddListener(() => {
            cardData.ApplyEffects();
            owner.Move(cardData);
            });
        
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
