using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{
    public GameObject question;
    public GameObject npc;

    void Start()
    {
        string newText = question.GetComponent<Text>().text;
        npc.GetComponent<Text>().text = newText;   
    }
}
