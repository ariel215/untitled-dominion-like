using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Cards {
    public class CardTemplate : MonoBehaviour
    {

        public TMP_Text CostText;
        public TMP_Text Name;
        public TMP_Text RulesText;

        // Start is called before the first frame update
        void Start()
        {

        }


        public void Init(CardData card)
        {
            CostText.text = card.Cost().ToString();
            Name.text = card.Name();
            RulesText.text = card.Text();

        }
    }
}