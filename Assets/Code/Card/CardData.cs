using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Effects;

public enum ResourceType { Early=0, Mid, Late};


namespace Cards
{

    [CreateAssetMenu(fileName ="New Card", menuName ="Card", order =0)]
    public class CardData: ScriptableObject
    {

        [SerializeField]
        private ResourceType costType;
        public ResourceType CostType() { return costType; }

        [SerializeField]
        private string cardName;
        public string Name() { return cardName; }
        [SerializeField]
        private int cost;
        public int Cost() { return cost; }
        [SerializeField]
        private int min_damage;
        public int MinDamage() { return min_damage; }
        [SerializeField]
        private int max_damage;
        public int MaxDamage() { return max_damage; }
        [SerializeField]
        public List<Effect> effects;


        public int CompareMin(CardData other)
        {
            return min_damage.CompareTo(other.min_damage);
        }

        public int CompareMax(CardData other)
        {
            return max_damage.CompareTo(other.max_damage);
        }

    }

}