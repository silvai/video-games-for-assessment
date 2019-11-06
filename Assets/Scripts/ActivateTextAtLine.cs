using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public GameManager globalObject;

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;

    // Start is called before the first frame update
    void Start()
    {
        globalObject = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Space))
        {
            globalObject.ReloadScript(theText);
            globalObject.currentLine = startLine;
            globalObject.endAtLine = endLine;
            globalObject.EnableTextBox();

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

            globalObject.ReloadScript(theText);
            globalObject.currentLine = startLine;
            globalObject.endAtLine = endLine;
            globalObject.EnableTextBox();

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
