using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwap : MonoBehaviour
{
    public GameObject mk, sam;
    public bool insideArea = true;

    int whichAvatarIsOn = 1;
    // Start is called before the first frame update
    void Start()
    {
        mk.gameObject.SetActive(true);
        sam.gameObject.SetActive(false);
    }

    public void SwitchCharacter()
    {
        switch (whichAvatarIsOn)
        {
            case 1:
                whichAvatarIsOn = 2;
                mk.gameObject.SetActive(false);
                sam.gameObject.SetActive(true);
                Debug.Log("sam");
                break;
            case 2:
                whichAvatarIsOn = 1;
                mk.gameObject.SetActive(true);
                sam.gameObject.SetActive(false);
                Debug.Log("mk");
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SwitchCharacter();
        }
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
