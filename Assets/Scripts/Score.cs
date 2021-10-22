using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static float Value = 0;
    TMPro.TMP_Text point;
    // Start is called before the first frame update
    void Start()
    {
        point = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        point.text ="" + Value;
    }
}
