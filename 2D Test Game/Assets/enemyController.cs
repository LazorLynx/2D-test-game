using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public bool insideArea;
    
    Animator animator;
    BoxCollider2D box2d;
    Rigidbody2D rb;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Battle Area")
        {
            insideArea = true;

        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Battle Area")
        {
            insideArea = false;
        }
    }
}
