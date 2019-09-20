//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Jump : MonoBehaviour {
//    public Vector2 jumpHeight;
//    Animator animator;
//    bool onGround = true;
//    int jumpCount = 0;
//    public float groundY;
//    public float speed;
//    Rigidbody2D rb;
//
//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//    }
//
//    void Update () {
//        //move right continuously
//        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
//        x += speed;
//        transform.Translate(x, 0, 0);
//
//        //limit to jumps onyl while on ground
//        onGround = (rb.position.y < (groundY)) ? true : false;
//        if (onGround) 
//        {
//            if (Input.GetKeyDown(KeyCode.UpArrow))
//            {
////                animator.SetInteger("jumping", 1);
//                animator.SetTrigger("jump");
//                GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
//            }
//            if (animator.GetInteger("jumping") == 1 && !Input.GetKeyDown(KeyCode.UpArrow))
//            {
//                //            new WaitForSecondsRealtime(2);
//                //              animator.SetInteger("jumping", 0);
//                animator.ResetTrigger("jump");
//            }
//            //animator.ResetTrigger("jump");
//        }
//
//        //reached end
//        if (rb.position.x > 310) 
//        {
//            //cannot jump
//            onGround = false;
//            //stop
//            speed = 0;
//            //sit
//            animator.SetTrigger("end");
//        }
//    }
//
//}
//
//
