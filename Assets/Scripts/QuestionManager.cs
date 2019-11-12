using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuestionManager : MonoBehaviour
{

    public TextAsset questionList;
    public string[] questions;
    public int score;
    private string currentString;
    public ScoreManager scoreManager;

    private int questionsAnswered = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        score = 0;
        setScoreText();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (questionList != null)
        {
            questions = (questionList.text.Split('\n'));
            Debug.Log("Number of questions: " + questions.Length);
        }
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    public string getNextQuestion()
    {
        if (questions != null)
        {
            Debug.Log("Grabbing question : " + (questionsAnswered));
            currentString = questions[questionsAnswered];
            return questions[questionsAnswered];
        }
        return null;
    }

    public void questionAnswered(int choice)
    {
        Debug.Log("QUESTION ANSWERED");
        questionsAnswered++;
        score++;
        setScoreText();

        string currentAnswer;
        if (choice == 1)
        {
            currentAnswer = "Strongly Agree";
        } else if (choice == 2)
        {
            currentAnswer = "Agree";
        } else if (choice == 3)
        {
            currentAnswer = "Neutral";
        } else if (choice == 4)
        {
            currentAnswer = "Disagree";
        } else
        {
            currentAnswer = "Strongly Disagree";
        }

        writeAnswer(currentString, currentAnswer);
        scoreManager.incrementScore();
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

    static void writeAnswer(string question, string answer)
    {
        string path = "Assets/answers.txt";
        string response = question + " : " + answer;

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(response);
        writer.Close();
    }
}
