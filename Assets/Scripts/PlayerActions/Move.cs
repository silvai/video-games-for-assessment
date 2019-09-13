using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float stepSize;
    public float slide;
    bool isClicked;
    public SpriteRenderer character;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    Animator animator;
    float x;
    float y;

    // Update is called once per frame
    void Update () {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * slide;
        transform.Translate(x, 0, 0);
        y = Input.GetAxis("Vertical") * Time.deltaTime * slide;
        transform.Translate(0, y, 0);
        animator = GetComponent<Animator>();

        //if (!isClicked)
        //{

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 position = this.transform.position;
                position.x -= stepSize;
                this.transform.position = position;
                character.sprite = leftSprite;
                animator.SetTrigger("left");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 position = this.transform.position;
                position.x += stepSize;
                this.transform.position = position;
                character.sprite = rightSprite;
                animator.SetTrigger("right");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector3 position = this.transform.position;
                position.y += stepSize;
                this.transform.position = position;
                character.sprite = upSprite;
                animator.SetTrigger("up");
        }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Vector3 position = this.transform.position;
                position.y -= stepSize;
                this.transform.position = position;
                character.sprite = downSprite;
                animator.SetTrigger("down");
        }
            //else
            //{
            //    animator.SetTrigger("stop");
            //}
        //}

    }
}
