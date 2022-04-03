using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCamera : MonoBehaviour
{
    public Camera frontCamera;
    public Camera backCamera;
    private GameObject door;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.Find("MovingDoor");
        frontCamera.enabled = false;
        backCamera.enabled = false; 
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if (other == player & player.transform.position.z < door.transform.position.z)
        {
            if (player.transform.position.z < door.transform.position.z)
            {
                frontCamera.enabled = true;
                backCamera.enabled = false; 
            }
            else if (player.transform.position.z > door.transform.position.z)
            {
                backCamera.enabled = true;
                frontCamera.enabled = false; 
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (player.transform.position.z < door.transform.position.z)
            {
                frontCamera.enabled = true;
                backCamera.enabled = false;
            }
            else if (player.transform.position.z > door.transform.position.z)
            {
                backCamera.enabled = true;
                frontCamera.enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            backCamera.enabled = false;
            frontCamera.enabled = false;
        }
    }
}
