using UnityEngine;
using System.Collections.Generic;
using System;
using Effects;

[CreateAssetMenu(fileName ="Opponent")]
public class Opponent: Player
{
    List<Effect> possibleEffects = new List<Effect>();

    Effect nextEffect;

    private static Opponent _instance;

    public static Opponent gOpponent
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Opponent>("Opponent");
            }
            return _instance;
        }
    }

    [SerializeField]
    int Damage;


    public void ChooseAction()
    {
        throw new NotImplementedException();
    }

    public void TakeAction()
    {
        nextEffect.Apply();
    }

    public void DealDamage(int n)
    {
        Damage += n;
    }
    
}
