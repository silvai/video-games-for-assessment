using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objectsToKeep;

    private void Awake()
    {
        foreach (GameObject o in objectsToKeep)
        {
            DontDestroyOnLoad(o);
        }
        /*
        GameObject[] objs = GameObject.FindGameObjectsWithTag("QuestionGenerator");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        */
    }
}
