using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextBox: MonoBehaviour
{
    public Collider2D coll;
    public GameObject itemNotTakenText;
    public GameObject itemTakenText;
    private GameObject currText;
    // private bool itemTaken;
      
    void Start()
    {
        itemNotTakenText.SetActive(false);
        itemTakenText.SetActive(false);
        currText = itemNotTakenText;
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        currText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        currText.SetActive(false);
        currText = itemTakenText;
        // itemTaken = true;
    }
    
}
