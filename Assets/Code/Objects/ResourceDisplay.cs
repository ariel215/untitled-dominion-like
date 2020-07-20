using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameResources
{

    public class ResourceDisplay : MonoBehaviour
    {

        private TMP_Text text;
        public ResourceType type;

        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            text.text = $"{ResourcePool.gPool.Resources[type]}";
        }
    }
}