using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorTrigger : MonoBehaviour
{

    public string nextRoom;
    TriggerSpeech check;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextRoom, LoadSceneMode.Single);
    }
}
