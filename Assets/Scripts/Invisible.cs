using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    private Animator anim;
    private HashIDs hash;
    private GameObject door;
    public Material opaque;
    public Material transparent;
    private Renderer rend;
    public ParticleSystem glow;

    void Awake()
    {
        door = GameObject.Find("MovingDoor");
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        rend = GameObject.Find("EthanBody").GetComponent<Renderer>();
        glow.Stop();
        glow.Clear();
    }

    void Update()
    {
        if (anim.GetBool(hash.safeBool))
        {
            rend.material = transparent;
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), door.GetComponent<Collider>(), true);
            glow.Play();
        }
        else
        {
            rend.material = opaque; 
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), door.GetComponent<Collider>(), false);
            glow.Stop();
        }
    }
}
