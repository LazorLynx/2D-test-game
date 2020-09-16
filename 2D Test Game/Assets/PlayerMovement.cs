using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool touchingTop = false;

    [HideInInspector] public bool activePlayer;
   

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    float moving;

    // Update is called once per frame
    void Update()
    {

        if (activePlayer)
        {
            // myLight = GetComponent<PlayerMovement>();
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }   

      
    }

    void Moving()
    {
        moving = horizontalMove;
    }
    //need if you want to use Sam-trigger
    //void OnTriggerEnter2D(Collider2D mkcol)
    //{
    //    if (mkcol.tag == "Top")
    //    {
    //        touchingTop = true;
    //    }

    //}
    //void OnTriggerExit2D(Collider2D mkother)
    //{
    //    if (mkother.tag == "Top")
    //    {
    //        touchingTop = false;
    //    }
    //}
    //public void Testing()
    //{
    //    if (touchingTop == true)
    //    {
    //        Debug.Log("stuff");
    //    }
        
    //}
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {

        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    

}
