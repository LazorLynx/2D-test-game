using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flip_sam : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

   // bool jump = false;
    //[SerializeField] private float m_JumpForce = 400f;
    //[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    //[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    //[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    //[SerializeField] private Transform m_GroundCheck;

    //const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
    //private bool m_Grounded;            // Whether or not the player is grounded.
    //private Rigidbody2D m_Rigidbody2D;
    //private Vector3 m_Velocity = Vector3.zero;
    //Rigidbody2D rb;
    //Animator anim;

    //[Header("Events")]
    //[Space]

    //public UnityEvent OnLandEvent;

    //[System.Serializable]
    //public class BoolEvent : UnityEvent<bool> { }



    //public CharacterController2D controller;
   // public Animator animator;

   // public float runSpeed = 40f;

    //float horizontalMove = 0f;
    //bool jump = false;
    bool crouch = false;

    //private void Awake()
    //{
    //    m_Rigidbody2D = GetComponent<Rigidbody2D>();

    //    if (OnLandEvent == null)
    //        OnLandEvent = new UnityEvent();


    //}
    //private void FixedUpdate()
    //{
    //    bool wasGrounded = m_Grounded;
    //    m_Grounded = false;

    //    // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    //    // This can be done using layers instead but Sample Assets will not overwrite your project settings.
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        if (colliders[i].gameObject != gameObject)
    //        {
    //            m_Grounded = true;
    //            if (!wasGrounded)
    //            {
    //                OnLandEvent.Invoke();
    //            }

    //        }
    //    }

    //    //Move our character
    //  //  controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    //   // jump = false;
    //}
    //private void OnCollisionEnter2D(Collision2D collision)

    //{

    //    if (collision.collider.gameObject.layer == 9)

    //    {
    //        OnLandEvent.Invoke();
    //    }
    //}

    //public void Move(float move, bool crouch, bool jump)
    //{
    //    //only control the player if grounded or airControl is turned on
    //    if (m_Grounded || m_AirControl)
    //    {
    //        // Move the character by finding the target velocity
    //        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
    //        // And then smoothing it out and applying it to the character
    //        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    //    }
    //    // If the player should jump...
    //    if (m_Grounded && jump)
    //    {
    //        // Add a vertical force to the player.
    //        m_Grounded = false;
    //        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
    //        Debug.Log("should jump");
    //    }
    //}
   
	

   
   

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }




   

    //public void OnLanding()
    //{
    //   // animator.SetBool("IsJumping", false);
    //}


}
