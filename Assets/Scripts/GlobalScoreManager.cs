using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScoreManager : MonoBehaviour
{
    public static GlobalScoreManager Instance;
    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
}
