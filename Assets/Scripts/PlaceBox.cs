using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBox : MonoBehaviour
{
    private GameObject weight;
    private bool moveTowards = false;
    public float speed = 2.0f;
    private GameObject rope;
    private GameObject door;
    private GameObject doorMover;
    private GameObject bigGear;
    private GameObject smallGear; 

    void Awake()
    {
        weight = GameObject.Find("Weight");
        rope = GameObject.Find("ExtraRope");
        door = GameObject.Find("Door");
        doorMover = GameObject.Find("DoorMover2");
        bigGear = GameObject.Find("BigGear");
        smallGear = GameObject.Find("SmallGear"); 

    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        float gearStep = speed * 45 * Time.deltaTime; 

        if (moveTowards)
        {
            weight.transform.position = Vector3.MoveTowards(weight.transform.position, new Vector3(gameObject.transform.position.x + 0.1f,
                                                                                                    gameObject.transform.position.y -0.35f, gameObject.transform.position.z), step);
            weight.GetComponent<Rigidbody>().useGravity = false; 
        }
        
        if (weight.transform.position == new Vector3(transform.position.x + .1f, transform.position.y - 0.35f, transform.position.z))
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 4f , transform.position.z), step);
            rope.transform.position = Vector3 .MoveTowards(rope.transform.position, new Vector3(rope.transform.position.x, 4.964f, rope.transform.position.z), step);
            door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3(3f, door.transform.position.y, door.transform.position.z), step);
            doorMover.transform.position = Vector3.MoveTowards(doorMover.transform.position, new Vector3(4f, doorMover.transform.position.y, doorMover.transform.position.z), step);
            if (bigGear.transform.rotation.x > 0)
            {
                bigGear.transform.Rotate(-Vector3.up * gearStep);
                smallGear.transform.Rotate(Vector3.up * 2 * gearStep);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == weight)
        {
            if (Input.GetButtonDown("Pickup"))
            {
                weight.GetComponent< Collider >().enabled = false;
                weight.transform.eulerAngles = new Vector3(-0, -0, 0);
                weight.GetComponent< Rigidbody >().constraints = RigidbodyConstraints.FreezeAll;
                weight.transform.parent = gameObject.transform;
                moveTowards = true; 
            }
        }
    }
}
