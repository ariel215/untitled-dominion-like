using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zones;

public class CardCounter : MonoBehaviour
{

    public Zone Zone;
    public TMP_Text _Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Text.text = Zone.Count().ToString();
    }
}
