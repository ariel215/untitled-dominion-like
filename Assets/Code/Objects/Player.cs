using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "Player", order = 1)]
public class Player: ScriptableObject
{
    private static Player _instance = null;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Player>("Player");
            }
            return _instance;
        }
    }

    public Dictionary<ResourceType, int> BaseResourceNumber = new Dictionary<ResourceType, int>
    {
        {ResourceType.Early, 0},
        {ResourceType.Mid,0 },
        {ResourceType.Late,0 }
    };

    [SerializeField]
    private float health;
    public float Health()
    {
        return health;
    }



}