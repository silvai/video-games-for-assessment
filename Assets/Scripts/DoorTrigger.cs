using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorTrigger : MonoBehaviour
{
    public GameObject player;
    PlayerManager pmScript;
    public string nextRoom;
    TriggerSpeech check;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        pmScript = (PlayerManager)player.GetComponent(typeof(PlayerManager));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pmScript.recordPlayerPosition();
        SceneManager.LoadScene(nextRoom, LoadSceneMode.Single);
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Play();
    }
}
