using UnityEngine;
using System.Collections;

namespace Effects
{
    public abstract class Effect: ScriptableObject {

        public abstract void Apply(GameState game); 
    };
    

}