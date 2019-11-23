using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;
    public GameObject phoneBox;

    public Text theText;
    public Text phoneText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public GameObject player;

    private bool phoneActive;
    public bool isActive;

    public bool stopPlayerMovement;

    public QuestionManager questionManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        questionManager = FindObjectOfType<QuestionManager>();
        phoneBox = GameObject.FindGameObjectWithTag("Phone");


        DisablePhoneBox();
        phoneActive = false;

        if (textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (player == null)
        {
            player = GameObject.Find("player");
        }

        if (textLines[currentLine].ToCharArray()[0] == '*')
        {
            theText.text = textLines[currentLine].Substring(1);
        } else
        {
            theText.text = textLines[currentLine];
        }


        if (Input.GetKeyDown(KeyCode.Space) && !phoneActive)
        {
            if (textLines[currentLine].ToCharArray()[0] == '*')
            {
                EnablePhoneBox();
            }
            Debug.Log("CHECK");
            currentLine++;
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    public void FindPlayer()
    {
        player = GameObject.Find("player");
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            if (player == null)
            {
                player = GameObject.Find("player");
            }
            player.GetComponent<Move>().canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.GetComponent<Move>().canMove = true;
    }

    public void EnablePhoneBox()
    {
        phoneBox.SetActive(true);
        phoneText.text = LoadQuestion();
        phoneActive = true;
        Debug.Log("Phone active");
    }

    public void DisablePhoneBox()
    {
        phoneBox.SetActive(false);
        phoneActive = false;
        Debug.Log("Phone not active");
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];

            textLines = (theText.text.Split('\n'));

        }
    }

    public string LoadQuestion()
    {
        string question = questionManager.getNextQuestion();
        Debug.Log("LoadQuestion : " + question);
        return question;
    }

    public void AcceptResponse(int choice)
    {
        Debug.Log("ACCEPT RESPONSE" + choice);
        questionManager.questionAnswered(choice);
        DisablePhoneBox();
    }
}

