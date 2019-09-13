
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithPlayer : MonoBehaviour
{
    public Transform player;
    private float offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position.x - player.transform.position.x;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x + offset, 0, -10);
    }
    //// LateUpdate is called after Update each frame
    //void LateUpdate () 
    //{
    //    // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    //    transform.position = player.transform.position + offset;
    //}

}
