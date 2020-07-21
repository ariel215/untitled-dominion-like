using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameResources
{

    public class ResourceDisplay : MonoBehaviour
    {

        public TMP_Text Count;
        public TMP_Text Kind;

        public ResourceType type;

        // Start is called before the first frame update
        void Start()
        {
            Kind.text = type.String();
        }

        // Update is called once per frame
        void Update()
        {
            Count.text = $"{ResourcePool.gPool.Resources[type]}";
        }
    }
}