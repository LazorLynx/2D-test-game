
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Astar_Sam : MonoBehaviour
{

    [SerializeField] private LayerMask layermask;

    public GameObject player;
    public Transform mk;
    Rigidbody2D rb;
   // Flip_sam flip;
    Animator animator;

    public PlayerMovement pm;
    public CharacterController2D controller;
    BoxCollider2D box2d;

    bool jump = false;
    bool crouch = false;
    //public float runSpeed = 40f;

    float horizontalMove = 0f;

    public bool isFlipped = false;

    public float moveRange = 10f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //rb = transform.GetComponent<Rigidbody2D>();

        pm = FindObjectOfType<PlayerMovement>();
        controller = FindObjectOfType<CharacterController2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        //follows MK and flips
        mk = GameObject.FindGameObjectWithTag("MK").transform;
        

        // flip = animator.GetComponent<Flip_sam>();
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        animator.SetBool("IsJumping", false);
        //Debug.Log("is grounded");
        return raycasthit2d.collider != null;


    }
    void FixedUpdate()
    {
        LookAtPlayer();

       

        if (mk.transform.rotation.eulerAngles.y >= -2 && mk.transform.rotation.eulerAngles.y <= 2)
        {
             //left side of player
            this.gameObject.transform.position = Vector2.MoveTowards
                  (
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x - 0.3f, player.transform.position.y, player.transform.position.z),
                5f * Time.deltaTime
                );

            if (pm.horizontalMove >= 1f )//(Vector2.Distance(mk.position, rb.position) > moveRange)
            {
                animator.SetBool("Run", true);
            }
            else if (pm.horizontalMove == 0f )//(Vector2.Distance(mk.position, rb.position) <= moveRange)
            {
                animator.SetBool("Run", false);
            }
            
            Debug.Log("facing right");
        } 
        else if(mk.transform.rotation.eulerAngles.y >= 178 && mk.transform.rotation.eulerAngles.y <= 182)
        {
                //right side of player
                this.gameObject.transform.position = Vector2.MoveTowards
                      (
                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    new Vector3(player.transform.position.x + 0.3f, player.transform.position.y, player.transform.position.z),
                    5f * Time.deltaTime
                    );
            
            Debug.Log("facing left");

            if(pm.horizontalMove <= -1f)//(Vector2.Distance(mk.position, rb.position) > moveRange)
            {
                animator.SetBool("Run", true);
            }
            else if (pm.horizontalMove == 0f)//(Vector2.Distance(mk.position, rb.position) <= moveRange)
            {
                animator.SetBool("Run", false);
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }
     }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < mk.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > mk.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

}
    


