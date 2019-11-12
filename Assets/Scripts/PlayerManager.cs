using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Keeps track of the player */

public class PlayerManager : MonoBehaviour
{

    float x, y;
    public GameObject player;
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion


    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void recordPlayerPosition()
    {
        Debug.Log(transform.position);
        x = transform.position.x;
        y = transform.position.y;
    }

}