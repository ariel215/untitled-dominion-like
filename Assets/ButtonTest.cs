using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ButtonLike))]
public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonLike>().OnClick.AddListener(Msg);
    }

    public void Msg()
    {
        Debug.Log("Pressed Button");
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
