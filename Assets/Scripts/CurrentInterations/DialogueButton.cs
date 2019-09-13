using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public GameObject introText;           //introductory text (i.e. "Hi I'm Bob")
    public GameObject button1;          //next button to see question
    public GameObject[] responses;      //response buttons
    public GameObject question;         //Textbox after introduction

    public void SwapImages()
    {
        introText.SetActive(false);     //hide the first text
        button1.SetActive(false);       //hide the "Ok!" button
        question.SetActive(true);       //display question
        if (responses.Length != 0)
        {
            foreach (GameObject response in responses)
            {
                response.SetActive(true);
            }
        }
    }

}
