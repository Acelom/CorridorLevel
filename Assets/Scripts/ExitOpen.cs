using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOpen : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos; 
    private GameObject player;
    private GameObject door;
    private bool interact;
    public float speed = 1.0f;
    private float step = 0;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.Find("ExitDoor"); 
    }

    void FixedUpdate()
    {

        step = speed * Time.deltaTime;
        if (!interact)
        {
            door.transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, step);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            interact = true;
        }

        if (interact & other.gameObject == player)
        {
            door.transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interact = false;
    }
}
