using UnityEngine;
using System.Collections.Generic;
using Effects;
using System;




namespace Cards
{

    public enum Kind { Random, Fixed };

    
    public class CardData: MonoBehaviour
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
        public Effect[] effects;

        static Dictionary<string, CardData> cardCache = new Dictionary<string, CardData>();

        private void Awake()
        {
            effects = GetComponents<Effect>();
        }


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

                if (!cardCache.ContainsKey(name))
                {
                    cardCache[name] = Resources.Load<CardData>($"Cards/Data/{name}");
                }
                var data = Instantiate(cardCache[name] ?? throw new Exception($"Could not load {name}"));
                cards.Add(data ?? throw new Exception($"Could not load {name}"));
            }
            return cards;
        }

        public void ApplyEffects()
        {
            Debug.Log($"Applying {effects.GetLength(0)} effects of {name}");
            foreach( var effect in effects)
            {
                effect.Apply();
            }
        }

        public string Text()
        {
            return string.Join<Effect>("\n", effects);
            
        }
        
    }

}