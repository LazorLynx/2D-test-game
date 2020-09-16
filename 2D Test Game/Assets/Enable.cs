using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum ActivePlayer { MK, Sam };

public class Enable : MonoBehaviour
{

    //public ActivePlayer activePlayer = new ActivePlayer();
   public static ActivePlayer activePlayer;


//Usefull code
//AIDesSetter = GetComponent<AIDestinationSetter>();
// GetComponent<AIDestinationSetter>().enabled = false;
//seeker.enabled = false;                                             For on same object, I think
//GameObject.Find("Sam").GetComponent<Seeker>().enabled = false;      For on different object
// mk.enabled = !mk.enabled;                                          For on same object

//Collider2D.OnCollisionStay2D(Collision2D)                           Sent each frame where a collider on another object is touching this object's collider
//Collider2D.OnCollisionExit2D(Collision2D)                           Sent when a collider on another object stops touching this object's collider
//Collider2D.OnCollisionEnter2D(Collision2D)                          Sent when an incoming collider makes contact with this object's collider 

    private CameraFollow cameraFollow;
    private PlayerMovement mk;
    private Player_Movement_Sam sam;
    public float horizontalMove = 0f;

    //private Vector2 facingDirection = Vector2.zero;

    private bool m_FacingRight = true;

    void Awake()
    {
        cameraFollow = GetComponent<CameraFollow>();
        mk = FindObjectOfType<PlayerMovement>();
        sam = FindObjectOfType<Player_Movement_Sam>();
        if (activePlayer == ActivePlayer.MK)
        {
            mk.activePlayer = true;
            activePlayer = ActivePlayer.MK;
            sam.activePlayer = false;
            cameraFollow.player = mk.transform;
            GameObject.Find("Sam").GetComponent<SamAI>().enabled = true;
            GameObject.Find("MK").GetComponent<MKAI>().enabled = false;
            
        }
        else if (activePlayer == ActivePlayer.Sam)
        {
            sam.activePlayer = true;
            mk.activePlayer = false;
            activePlayer = ActivePlayer.Sam;
            cameraFollow.player = sam.transform;
            GameObject.Find("Sam").GetComponent<SamAI>().enabled = false;
            GameObject.Find("MK").GetComponent<MKAI>().enabled = true;
            
        }
    }
    /*
    public void Move(float move, bool crouch, bool jump)
    {
        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (activePlayer == ActivePlayer.MK)
             {
             //   Move(0f, false, false);
               
                // if (movement_vector == Vector2.right)
              //  {
                //    transform.Rotate(0f, 0f, 0f);
                    //facingDirection = movement_vector;  // You save the direction only when the object is moving
                    // direction.Normalize() // Normalize it as the magnitude does not give any valuable information
                    //transform.rotation.y
                    // Vector3.Dot(object.normalize, Vector3.forward);
                    //if Vector3
               // }
               // else if (movement_vector == Vector2.left)
               // {
                 //   transform.Rotate(0f, 180f, 0f);
               // }
                    activePlayer = ActivePlayer.Sam;
                sam.activePlayer = true;
                mk.activePlayer = false;
                cameraFollow.player = sam.transform;
                GameObject.Find("Sam").GetComponent<SamAI>().enabled = false;
                GameObject.Find("MK").GetComponent<MKAI>().enabled = true;
                Debug.Log("Sam active player");

            }
            else if (activePlayer == ActivePlayer.Sam)
            {                
                activePlayer = ActivePlayer.MK;
                sam.activePlayer = false;
                mk.activePlayer = true;
                cameraFollow.player = mk.transform;
                GameObject.Find("Sam").GetComponent<SamAI>().enabled = true;
                GameObject.Find("MK").GetComponent<MKAI>().enabled = false;
                Debug.Log("MK active player");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (activePlayer == ActivePlayer.MK)
        {
            if (col.gameObject.tag == "Sam")
            {
                Debug.Log("MK touch sam");
                GameObject.Find("Sam").GetComponent<SamAI>().enabled = false;
            }
            else
            {
                 GameObject.Find("Sam").GetComponent<SamAI>().enabled = true;
            }

        }
        
        else if (activePlayer == ActivePlayer.Sam)
        {
            if (col.gameObject.tag == "MK")
            {
                Debug.Log("Sam touch MK");
                GameObject.Find("MK").GetComponent<MKAI>().enabled = false;
            }
            else
            {
                
                GameObject.Find("MK").GetComponent<MKAI>().enabled = true;
            }

        }


    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
