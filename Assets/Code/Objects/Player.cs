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

    [SerializeField]
    private float health;
    public float Health()
    {
        return health;
    }



}