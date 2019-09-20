using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJumpPhysics : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0) { //If we are falling
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1)
                * Time.deltaTime; //minus 1 to account for gravity
            }
    }
}

        
		

    
