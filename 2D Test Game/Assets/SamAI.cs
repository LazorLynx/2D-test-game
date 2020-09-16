using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SamAI : MonoBehaviour
{
    [HideInInspector] public bool activePlayer;
   // public Enable enable;    

    public Transform target;
    public Animator animator;

    public float speed = 200f;
    public float nextWaypointDisdance = 3f;

    public Transform samGFX;
    public float runSpeed = 40f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool canFly = false;
    float horizontalMove = 0f;

    Seeker seeker;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        {
            seeker = GetComponent<Seeker>();
            rb = GetComponent<Rigidbody2D>();

            InvokeRepeating("UpdatePath", 0f, .5f);

        }


    }
        void UpdatePath()
        {
            if (!activePlayer)
            {
                if (seeker.IsDone())
                {
                    seeker.StartPath(rb.position, target.position, OnPathComplete);
                }

            }
        }

        void OnPathComplete(Path p)
        {
            if (!activePlayer)
            {
                if (!p.error)
                {
                    path = p;
                    currentWaypoint = 0;
                }

            }

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!activePlayer)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

                if (path == null)
                    return;

                if (currentWaypoint >= path.vectorPath.Count)
                {
                    reachedEndOfPath = true;
                    return;
                }
                else
                {
                    reachedEndOfPath = false;
                }

                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position); //.normalized;
                                                                                               //Vector2 force = direction * speed * Time.deltaTime;
                Vector2 force = direction * speed * Time.deltaTime;  // force that will move the enemy in the desired direction
                Vector2 velocity = rb.velocity;


                if (canFly)
                { // If a flyer, apply velocity in all directions
                  // rb.AddForce(force);  // the old method
                velocity = force;
                    rb.velocity = velocity;
                }

                else

                { // If not a flyer, only apply velocity to the x axis
                  velocity.x = force.x;
                    rb.velocity = velocity;

                }

                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
                if (distance < nextWaypointDisdance)
                {
                    currentWaypoint++;
                }

                if (force.x >= 0.01f)
                {
                    samGFX.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (force.x <= -0.01f)
                {
                    samGFX.localScale = new Vector3(1f, 1f, 1f);
                }
            }




        }
    }


        
    
            


