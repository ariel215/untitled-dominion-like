using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HealthTracker : MonoBehaviour
{

    TMP_Text text;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{player.Health()} / {player.MaxHealth}";
    }
}
