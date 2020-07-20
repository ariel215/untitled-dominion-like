using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AlignedScale))]
public class HPScale : MonoBehaviour
{

    public AlignedScale bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<AlignedScale>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = Player.gPlayer;

    }
}
