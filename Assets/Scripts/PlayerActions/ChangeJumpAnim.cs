using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeJumpAnim : MonoBehaviour {
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetInteger("jumping", 1);
            anim.SetTrigger("jump");
        }
        else {
            anim.SetInteger("jumping", 0);
            anim.ResetTrigger("jump");

        }

    }
}
