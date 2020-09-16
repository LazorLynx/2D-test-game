using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAI_new : MonoBehaviour
{
    // public GameObject Player;

    //Transform myTransform;

    bool jump = false;
    public bool touchingBottom = false;
    public bool touchingTop = false;

    public float speed = 20f;
    public float moveRange = 0.3f;
    public float teleportRange = 5f;

    float jumpYSpeed = 2;
    float jumpZSpeed = 1;

    float jumpSpeed = 10f;
    //float horizontalMove = 0f;

    //[SerializeField] private float m_JumpForce = 700f;

    [SerializeField] private LayerMask layermask;

    public PlayerMovement pm;

    Transform mk;
    Transform sam;
    Rigidbody2D rb;
    Flip_sam flip;
    Animator animator;
    BoxCollider2D box2d;


    private Vector2 target;
    private Vector2 position;


    public float runSpeed = 1f;

    private void Awake()
    {
       // myTransform = transform;
        animator = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
       // PlayerMovement pm;
        //Collider2D collider = GetComponentInChildren<Collider2D>();
       pm = FindObjectOfType<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //follows MK and flips
        mk = GameObject.FindGameObjectWithTag("MK").transform;
        sam = GameObject.FindGameObjectWithTag("Sam").transform;
        //rb = animator.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        flip = animator.GetComponent<Flip_sam>();

        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        // rb.velocity = new Vector2(speed, 0);
    }

    //void Update()
    //{
    //    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    //}

    // Update is called once per frame
    void Update()
    {


    }
    

   //can also use stay instead of enter
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bottom")
        {
            touchingBottom = true;

        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Bottom")
        {
            touchingBottom = false;
        }
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
        flip.LookAtPlayer();

        if (pm.touchingTop && touchingBottom)
        {
            rb.velocity = new Vector2(1f, 5.5f);
            // float step = speed * Time.deltaTime;
           // step = speed * Time.fixedDeltaTime;
           // transform.position = Vector2.MoveTowards(transform.position, mk.transform.position, step);
            //sam.transform.position = mk.position;
            touchingBottom = false;
            //rb.AddForce(new Vector3(2, 10, 0), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
            animator.SetBool("Run", false);
            //pm.Testing();


        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Vector3 displacement = mk.position - transform.position;
        displacement = displacement.normalized;

        if (IsGrounded() && Vector2.Distance(mk.position, rb.position) <= moveRange)
        {
            jump = false;
            //animator.SetBool("IsJumping", false);
            animator.SetBool("Run", false);
            animator.SetFloat("Speed", 1f);

            //animator.ResetTrigger("Ifclose");
            // Debug.Log("If close");

        }
        if (IsGrounded() && Vector2.Distance(mk.position, rb.position) > moveRange)
        {
            jump = false;
            // animator.SetBool("IsJumping", false);
            animator.SetBool("Run", true);
            animator.SetFloat("Speed", 3f);
            //Vector2 target = new Vector2(mk.position.x, rb.position.y);
            //Vector2 newPos = Vector2.MoveTowards(rb.position, target, runSpeed * Time.fixedDeltaTime);
            //rb.MovePosition(newPos);

            transform.position += (displacement * speed * Time.deltaTime);
        }
        if (Vector2.Distance(mk.position, rb.position) > teleportRange)
        {
            animator.SetBool("Run", false);
            animator.SetFloat("Speed", 1f);
            //Debug.Log("teleport");
            sam.transform.position = mk.position;
            //sam.transform.rotation = mk.position;

        }

        //Move our character

        jump = false;
    }

}
