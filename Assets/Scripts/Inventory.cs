using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

	#region Singleton

	public static Inventory instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnItemChanged();

	public OnItemChanged onItemChangedCallback;

	public int space = 10;	// Amount of slots in inventory

	// Current list of items in inventory
	public List<Item> items = new List<Item>();

    // Add a new item. If there is enough room we
    // return true. Else we return false.
    public bool Add (Item item)
	{
		// Don't do anything if it's a default item
		// Check if out of space
		if (items.Count >= space)
		{
			//Debug.Log("Not enough room.");
			return false;
		}

		items.Add(item);	// Add item to list

		// Trigger callback
		if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        //Debug.Log("Items list now is " + items);
		return true;
	}

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);     // Remove item from list

        // Trigger callback
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
