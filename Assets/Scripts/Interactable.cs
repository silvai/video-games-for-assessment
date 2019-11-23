using UnityEngine;


public class Interactable : MonoBehaviour {

	public float radius = 3f;
    public Item neededItem;
    public Item possessedItem;
    
    bool hasInteracted;

	public virtual void Interact ()
	{
		
		//Debug.Log("Interacting with " + transform.name);
	}

	void Update ()
	{
        
	}
    
}
