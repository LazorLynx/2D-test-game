using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed = 1f;
   // private GameObject Player;
    public Transform Player;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        //Player = GameObject.Find("MK");
    }

    void FixedUpdate()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        //moving towards
        if (Vector2.Distance(Player.position, transform.position) >= 0.3f)
        {
            transform.position += (displacement * speed * Time.deltaTime);
            animator.SetBool("Run", true);
            animator.SetFloat("Speed", 3f);

        }//next to player
        else if (Vector2.Distance(Player.position, transform.position) < 0.3f)
        {
            animator.SetBool("Run", false);
            animator.SetFloat("Speed", 1f);
        }
        
    }
}
