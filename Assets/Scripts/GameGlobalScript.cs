using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameGlobalScript : MonoBehaviour
{
    public static GameGlobalScript instance;
    public int outdoorX, outdoorY;
    public GameObject playerObject;
    public int score;
    public TextAsset scoreText;

    void Start()
    {
        score = 0;
    }
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void UpdatePlayerPosition()
    {
        var playerPos = playerObject.transform.position;
        Debug.Log(playerPos);
    }

    public void incrementScore()
    {
        score++;
    }
    public int getScore()
    {
        return score;
    }
}