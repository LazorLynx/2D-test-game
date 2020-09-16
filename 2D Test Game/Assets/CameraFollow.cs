using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing;
    public float offsetHeight;
    public float zoom;
    public float zoomSmoothing;

    [HideInInspector] public Transform player;
    [HideInInspector] public Transform target;
    [HideInInspector] public float tSmoothing;
    [HideInInspector] public float tOffsetHeight;
    [HideInInspector] public float tZoom;
    [HideInInspector] public float tZoomSmoothing;

    private Vector3 movePos;
    private Vector3 camVelocity;
    private float zoomVelocity;
    private Camera mCam;

    // Start is called before the first frame update
    void Awake()
    {
        //If camera is not using component Enable then this will set camera to a player (Use for singleplayer on screen)
        //remove an ! before Getcomponent and fixed issue
        if (GetComponent<Enable>())
        {
            if (GameObject.Find("MK"))
            {
                player = GameObject.Find("MK").transform;
            }
            else 
            {
                player = GameObject.Find("Sam").transform;
            }
        }
        mCam = GetComponent<Camera>();
        mCam.orthographicSize = zoom;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
        {
            movePos = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, player.position.y + offsetHeight, -10), ref camVelocity,smoothing, Mathf.Infinity, Time.deltaTime);
            mCam.orthographicSize = Mathf.SmoothDamp(mCam.orthographicSize,zoom, ref zoomVelocity, zoomSmoothing, Mathf.Infinity, Time.deltaTime);
        }
        else
        {
            movePos = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y + offsetHeight, -10), ref camVelocity, tSmoothing, Mathf.Infinity, Time.deltaTime);
            mCam.orthographicSize = Mathf.SmoothDamp(mCam.orthographicSize, tZoom, ref zoomVelocity, tZoomSmoothing, Mathf.Infinity, Time.deltaTime);
        }
        transform.position = movePos;
    }
}
