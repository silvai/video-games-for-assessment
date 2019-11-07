using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{

    public TextAsset questionList;
    public string[] questions;
    public Text scoreText;
    public int score;
    GlobalScoreManager scoreManager;

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
        scoreManager = GlobalScoreManager.Instance;

        if (questionList != null)
        {
            questions = (questionList.text.Split('\n'));
            Debug.Log("Number of questions: " + questions.Length);
        }
        score = scoreManager.score;
        setScoreText();

    }

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
        //saveScore();
    }

    public void setScoreText()
    {
        scoreText.text = "Score: " +  score.ToString() + " / 20";
    }

    public void saveScore()
    {
        scoreManager.score = score;
    }
}
