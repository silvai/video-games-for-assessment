using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameGlobalScript : MonoBehaviour
{
    public static GameGlobalScript i;
    public int outdoorX, outdoorY;
    public GameObject playerObject;

    public TextAsset questionList;
    public string[] questions;
    //public Text scoreText;
    public int score;

    public GameObject textBox;
    public GameObject phoneBox;

    public Text theText;
    public Text phoneText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    private bool phoneActive;
    public bool isActive;

    public bool stopPlayerMovement;

    private int questionsAnswered;

    void Start()
    {
        questionsAnswered = 0;
        if (questionList != null)
        {
            questions = (questionList.text.Split('\n'));
            Debug.Log("Number of questions: " + questions.Length);
        }
        //score = GlobalScoreScript.Instance.score;
        //setScoreText();

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


    // Update is called once per frame
    void Update()
    {

        if (!isActive)
        {
            return;
        }

        if (textLines[currentLine].ToCharArray()[0] == '*')
        {
            theText.text = textLines[currentLine].Substring(1);
        }
        else
        {
            theText.text = textLines[currentLine];
        }


        if (Input.GetKeyDown(KeyCode.Space) && !phoneActive)
        {
            if (textLines[currentLine].ToCharArray()[0] == '*')
            {
                EnablePhoneBox();
            }
            currentLine++;
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    void Awake () {
        if(!i) {
           i = this;
           DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);

        score = 0;
        setScoreText();
    }

    public void UpdatePlayerPosition() {
        var playerPos = playerObject.transform.position;
        Debug.Log(playerPos);
    }


    /*
     *  QUESTIONS FUNCTIONALITY
     */

    public string getNextQuestion()
    {
        if (questions != null)
        {
            Debug.Log("Grabbing question : " + (questionsAnswered));
            return questions[questionsAnswered];
        }
        return null;
    }

    public void questionAnswered(int choice)
    {
        questionsAnswered++;
        score++;
        setScoreText();
    }

    public void setScoreText()
    {
        //    scoreText.text = "Score: " +  score.ToString() + " / 20";
    }

    public void saveScore()
    {
        //GlobalScoreScript.Instance.score = score;
        //GlobalScoreScript.Instance.scoreText = scoreText;
    }

    public int getScore()
    {
        return score;
    }


    /*
     *  TEXT BOX FUNCTIONALITY
     */

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            playerObject.GetComponent<Move>().canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        playerObject.GetComponent<Move>().canMove = true;
    }

    public void EnablePhoneBox()
    {
        phoneBox.SetActive(true);
        phoneText.text = LoadQuestion();
        phoneActive = true;
    }

    public void DisablePhoneBox()
    {
        phoneBox.SetActive(false);
        phoneActive = false;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];

            textLines = (theText.text.Split('\n'));

        }
    }

    public string LoadQuestion()
    {
        string question = getNextQuestion();
        Debug.Log("LoadQuestion : " + question);
        return question;
    }

    public void AcceptResponse(int choice)
    {
        Debug.Log("ACCEPT RESPONSE" + choice);
        questionAnswered(choice);
        DisablePhoneBox();
    }
}
