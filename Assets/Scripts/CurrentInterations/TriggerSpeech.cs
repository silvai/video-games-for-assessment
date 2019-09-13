using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggerSpeech : MonoBehaviour
{
    public GameObject textbox;
    public GameObject[] arrows;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
        foreach (GameObject a in arrows)
        {
            a.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textbox.SetActive(true);
        foreach (GameObject a in arrows) {
            a.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textbox.SetActive(false);
    }


}
