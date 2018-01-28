using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 10;
    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("idle", true);
    }

    void Update ()
	{
        Move();
	}

    void Move()
    {
        animator.SetBool("idle", false);
       if (Input.GetKey("up")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("left", true);
            animator.SetBool("right", false);
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("right")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("left")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("left", true);
            animator.SetBool("right", false);
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("idle", true);
        }
    }
}
