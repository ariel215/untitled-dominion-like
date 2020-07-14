using UnityEngine;
using System;


/// <summary>
/// Classes representing the different discrete effects
/// that objects can have on the game state
/// 
/// </summary>
namespace Effects
{
    public abstract class Effect: MonoBehaviour {

        public abstract void Apply();

        
    };
    


    
}