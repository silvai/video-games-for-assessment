using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SaveResponses : MonoBehaviour
{
    public GameObject responseSet;
    public Button response;
    public GameObject question;         //Textbox after introduction
    public GameObject thanks;
    bool clicked;

    public void HideResponses()
    {
        question.SetActive(false);
        thanks.SetActive(true);
    }

    public void SetClicked()
    {
        clicked = true;
    }

    public bool GetClicked()
    {
        bool temp = clicked;
        clicked = false;
        return temp;
        //if a method is asking for clicked we want to reset it
        //so that answering one question does not instantly mean
        //every question has been answered
        //return temp;
    }


    public void SaveToCSVSD()
    {
        using (StreamWriter writer = File.AppendText("Assets/Data/results.rtf"))
        {
            writer.WriteLine("Question: " + question.GetComponent<Text>().text + " . . . . " + response.name);
            writer.Close();
        }
    }
    
}
