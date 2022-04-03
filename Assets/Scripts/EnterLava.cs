using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLava : MonoBehaviour
{
    public ParticleSystem flames;
    public ParticleSystem glow;
    public ParticleSystem smoke;
    public GameObject lava; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == lava)
        {
            flames.Play();
            glow.Play();
            smoke.Play();
            Debug.Log("Emit");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lava)
        {
            flames.Play();
            glow.Play();
            smoke.Play();
            Debug.Log("Emit");
        }
    }
}
