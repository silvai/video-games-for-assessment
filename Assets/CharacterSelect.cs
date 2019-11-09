using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    int option = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goLeft()
    {
        if (option > 1)
        {
            option--;
        }
    }

    public void goRight()
    {
        if (option < 3)
        {
            option++;
        }
    }
}
