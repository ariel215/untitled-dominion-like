using UnityEngine;
using System.Collections.Generic;

using Cards;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class CardDisplay : MonoBehaviour
{

    public CardPool CardPool;
    public Vector2 LeftEdge;
    public float CardSize;
    public float MarginSize;
    SpriteRenderer renderer;

    List<GameObject> CardObjects = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        LeftEdge = transform.position;
        LeftEdge.x -= renderer.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < CardObjects.Count; ++i)
        {
            var pos = new Vector2(LeftEdge.x, LeftEdge.y);
            pos.x += (2 * MarginSize) + CardSize;
            if (CardObjects[i] != null)
            {
                CardObjects[i].transform.position = pos;
            }
        }
    }

    public void Add(CardData cardData, int idx)
    {
        if (idx >= CardObjects.Count)
        {
            while (CardObjects.Count <= idx)
            {
                CardObjects.Add(null);
            }
        }
        CardObjects[idx] = CardPool.GetObject(cardData);
        // take the opportunity to initialize card size
        if (CardSize == 0)
        {
            var renderer = CardObjects[idx].GetComponent<SpriteRenderer>();
            CardSize = renderer.bounds.extents.x;
            LeftEdge.x += CardSize;
        }
    }

    public void Remove(int idx)
    {
        CardObjects[idx] = null;
    }


    
}
