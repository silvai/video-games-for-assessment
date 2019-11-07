using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameGlobalScript : MonoBehaviour
{
    public static GameGlobalScript i;
    public int outdoorX, outdoorY;
    public GameObject playerObject;
    void Start()
    {
        //Button btn = myButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        if (!i)
        {
            i = this;
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
}