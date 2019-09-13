using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] responses;      //response buttons
    public GameObject text;         //Textbox after introduction
    public GameObject thanks;
    private Question q;                 //Actual HEXACO Question text for 
                                        // question object
    public Collider2D collision;
    private bool inRange = false;

    void Awake()
    {
        canvas.SetActive(false);
        thanks.SetActive(false);
        text.SetActive(true);
        q = Question.instance;
        text.GetComponent<Text>().text = q.GetQuestion();   //Set the question to the first Hexaco Question
    }

    
    private void Update()
    {
        if (inRange == true)
        {
            canvas.SetActive(true);
            foreach (GameObject response in responses)
            {
                if (response.GetComponent<SaveResponses>().GetClicked())
                {
                    text.SetActive(false);
                    thanks.SetActive(true);
                    text.GetComponent<Text>().text = q.GetQuestion();       //If the previous question was answered, set the question to the next one
                }
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        if (canvas != null)
            canvas.SetActive(false);
    }

}
