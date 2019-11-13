using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{

    public TextAsset theText;
    public TextAsset itemRequiredText;
    public Item neededItem;
    public Item collectedItem;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;
    private bool receivedItem;

    public bool destroyWhenActivated;

    // Start is called before the first frame update
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Space))
        {
            if (neededItem != null && Inventory.instance.items.Contains(neededItem))
            {
                Inventory.instance.Remove(neededItem);
                Debug.Log("Required item removed from inventory");
            }
            else if (neededItem != null && !Inventory.instance.items.Contains(neededItem))
            {
                Debug.Log("You don't have the required item");
            }
            if (collectedItem != null && !Inventory.instance.items.Contains(collectedItem))
            {
                Inventory.instance.Add(collectedItem);
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            waitForPress = false;
        }
    }
}