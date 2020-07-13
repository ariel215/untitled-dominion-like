using UnityEngine;
using System.Collections.Generic;
using Effects;

public class Opponent
{
    List<Effect> possibleEffects = new List<Effect>();

    Effect nextEffect;

    public void ChooseAction()
    {
        // IMPLEMENT ME
    }

    public void TakeAction()
    {
        nextEffect.Apply();
    }
    
    
}
