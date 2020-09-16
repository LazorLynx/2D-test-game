using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImove : StateMachineBehaviour
{
    bool jump = false;

    public float speed = 1f;
    public float moveRange = 0.3f;

    [SerializeField] private float m_JumpForce = 700f;

    Transform mk;
    Rigidbody2D rb;
    Flip_sam flip;

    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //follows MK and flips
        mk = GameObject.FindGameObjectWithTag("MK").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flip = animator.GetComponent<Flip_sam>();

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, m_JumpForce));
            jump = true;
            animator.SetBool("Run", false);
            animator.SetBool("IsJumping", true);
            animator.SetFloat("Speed", 1f);
           
            //if (collision.gameObject.tag == "MyGameObjectTag")
            
        }
       

        flip.LookAtPlayer();

        if (Vector2.Distance(mk.position, rb.position) <= moveRange)
        {
            animator.SetBool("Run", false);
            animator.SetFloat("Speed", 1f);

            //animator.ResetTrigger("Ifclose");
            // Debug.Log("If close");
            //Vector2 target = new Vector2(mk.position.x, rb.position.y);
            //Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            //rb.MovePosition(newPos);
        }
        if (Vector2.Distance(mk.position, rb.position) > moveRange)
        {
            animator.SetBool("Run", true);
            animator.SetFloat("Speed", 3f);
             Vector2 target = new Vector2(mk.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        

        //void OnLanding()
        //{
        //    animator.SetBool("IsJumping", false);
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.SetBool("IsJumping", false);
        jump = false;
        // animator.ResetTrigger("Ifclose");
        //animator.SetTrigger("Not Idle");
        // animator.ResetTrigger("Not Idle");

    }

    

}
