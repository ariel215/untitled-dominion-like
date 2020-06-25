using UnityEngine;

namespace Cards
{
    public class Card: MonoBehaviour
    {

        public CardData CardData { get; private set; }
        public Zones.Zone Zone { get; private set; }
        bool Selected = false;

        private void OnMouseUpAsButton()
        {
            if (Selected)
            {
                Zone.Move(CardData);
                Zone = Zone.Destination;
            }
            else
            {
                Selected = true;
            }
        }

    }
}
