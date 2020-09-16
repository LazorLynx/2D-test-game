using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    public float speed;

    //onstateenter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //onstateupdate is called on each update frame between onstateenter and onstateexit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isFollowing", false);
        }
    }

    //onstateexit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
