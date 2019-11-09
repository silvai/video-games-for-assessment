using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour 
    {

    public string location;
    public GameObject[] avatars;
    public Vector2 shift;
    public int leftEdge;
    public int rightEdge;
    private Vector2 realShift;

        
    public void OnMouseClicked(string location) {
        SceneManager.LoadScene(location, LoadSceneMode.Single);
    }

    public void LeftShift()
    {
            foreach (GameObject a in avatars)
            {
                if (a.transform.position.x <= leftEdge)
                {
                    realShift = new Vector2(0,0);
                }
                else
                {
                    realShift = shift;
                }
            a.transform.Translate(-realShift);
            }

    }

    public void RightShift() {
            foreach (GameObject a in avatars)
            {
                if (a.transform.position.x >= rightEdge)
                {
                    realShift = new Vector2(0, 0);
                }
                else
                {
                    realShift = shift;
                }
            a.transform.Translate(realShift);
            }
    }

}
 