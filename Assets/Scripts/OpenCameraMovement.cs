using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCameraMovement : MonoBehaviour
{
    private GameObject player;
    public GameObject cameraLocation; 
    public Camera openCamera;
    public float speed = 1.0f;
    private float step;
    private bool moveTowards; 


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        step = speed * Time.deltaTime;
        if (moveTowards)
        {
            openCamera.transform.position = Vector3.MoveTowards(openCamera.transform.position, cameraLocation.transform.position, step);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        openCamera.enabled = true; 
        if (other.gameObject == player)
        {
            moveTowards = true;    
        }
    }

    private void OnTriggerStay(Collider other)
    {
        openCamera.enabled = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        openCamera.enabled = false;
        moveTowards = false; 
    }
}
