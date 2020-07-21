using UnityEngine;
using TMPro;

namespace Cards {
    public class CardTemplate : MonoBehaviour
    {

        public TMP_Text CostText;
        public TMP_Text Name;
        public TMP_Text RulesText;

        public SpriteRenderer picture;

        // Start is called before the first frame update
        void Start()
        {

        }


        public void Init(CardData card)
        {
            CostText.text = card.Cost().ToString();
            Name.text = card.Name();
            RulesText.text = card.Text();

            SetPicture(card.name);
            gameObject.name = $"{card.Name()} Template";
          }

        void SetPicture(string name)
        {
            if (picture != null)
            {
                picture.sprite = Resources.Load<Sprite>($"Cards/Pictures/{name}");
            }
        }
    }
}