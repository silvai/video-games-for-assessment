using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem : MonoBehaviour
{
    public Sprite sprite;
    public GameObject item;
    public string inventoryKey;
    // public bool disableOnEnter;

    void Start(){}
    void Update() {}

    string getKey()
    {
        return inventoryKey;
    }
}
