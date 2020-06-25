using UnityEngine;
using System.Collections.Generic;
using Zones;
using Cards;

/// <summary>
/// 
/// </summary>

public class CardDisplay : MonoBehaviour
{

    public CardPool CardPool;
    public Vector2 LeftEdge;
    public float CardSize;
    public float MarginSize;

    List<GameObject> CardObjects = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        LeftEdge = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < CardObjects.Capacity; ++i)
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
        if (idx >= CardObjects.Capacity)
        {
            CardObjects.Capacity = idx + 1;
        }
        CardObjects[idx] = CardPool.GetObject(cardData);
    }

    public void Remove(int idx)
    {
        CardObjects[idx] = null;
    }


    
}
