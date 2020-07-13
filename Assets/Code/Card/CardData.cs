using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Effects;
using System;




namespace Cards
{

    public enum Kind { Random, Fixed };

    [CreateAssetMenu(fileName ="New Card", menuName ="Card", order =0)]
    public class CardData: ScriptableObject
    {

        [SerializeField]
        private GameResources.ResourceType costType;
        public GameResources.ResourceType CostType() { return costType; }

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
        private Kind kind;
        public Kind Kind() { return kind; }

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

        public static List<CardData> LoadList(TextAsset cardNames)
        {
            List<CardData> cards = new List<CardData>();
            string[] seps = { "\r", "\n", "\r\n" };
            foreach (var line in cardNames.text.Split(seps, StringSplitOptions.RemoveEmptyEntries))
            {
                var name = line.Trim();
                var data = Resources.Load<CardData>($"Cards/Data/{name}");
                cards.Add(data);
            }
            return cards;
        }

        public void ApplyEffects()
        {
            foreach( var effect in effects)
            {
                effect.Apply();
            }
        }
        
    }

}