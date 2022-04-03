using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speedDampTime = 0.01f;

    private Animator anim;
    private HashIDs hash;
    private float distToGround;
    private Color rayColor; 

    private void Awake()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float u = Input.GetAxis("Horizontal");
        bool sprint = Input.GetButton("Sprint");
        bool jump = Input.GetButton("Jump");
        bool invisible = Input.GetButton("Invisible");
        Rotating(u);
        ControlsManager(jump, invisible);
        MovementManager(v, sprint);

    }

    void Rotating(float horizontal)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();
        if (horizontal != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, horizontal, 0f);
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
            anim.SetFloat(hash.turningInt, horizontal);
        }
    }

    void MovementManager(float vertical, bool running)
    {
        if (vertical > 0 && running == true)
        {
            anim.SetFloat(hash.speedFloat, 3.0f, speedDampTime, Time.deltaTime);
            if (!anim.GetBool(hash.groundedBool))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 150f);
            }
        }
        else if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            if (!anim.GetBool(hash.groundedBool))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
            }
        }
        else if (vertical < 0)
        {
            anim.SetFloat(hash.speedFloat, -1f, speedDampTime, Time.deltaTime);
            if (!anim.GetBool(hash.groundedBool))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 75f);
            }
        }
        else
        {
            anim.SetFloat(hash.speedFloat, 0);
        }
        anim.SetBool(hash.sprintingBool, running);
    }

    void ControlsManager(bool jumping, bool safe)
    {
        anim.SetBool(hash.groundedBool, !isGrounded());
        if (!safe)
        {
            anim.SetBool(hash.jumpBool, jumping);
            if (jumping & anim.GetBool(hash.groundedBool))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 200f);
            }
        }
        anim.SetBool(hash.safeBool, safe);
    }

    void AudioManagement ()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walking") || anim.GetCurrentAnimatorStateInfo(0).IsName("TurnLeftWalk") || anim.GetCurrentAnimatorStateInfo(0).IsName("TurnRightWalk"))
        {
            if (!GetComponent<AudioSource>().isPlaying && !(GetComponent<AudioSource>().pitch == 0.27f))
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().pitch = 0.27f;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sprint") || anim.GetCurrentAnimatorStateInfo(0).IsName("TurnLeftRun") || anim.GetCurrentAnimatorStateInfo(0).IsName("TurnRightRun"))
        {
            if (!GetComponent<AudioSource>().isPlaying && !(GetComponent<AudioSource>().pitch == 0.54f))
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().pitch = 0.54f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop(); 
        }

    }

    bool isGrounded()
    {
        if (Physics.Raycast(GetComponent<Collider>().transform.position, -Vector3.up, distToGround + 1f))
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green; 
        }
        Debug.DrawRay(GetComponent<Collider>().transform.position, -Vector3.up, rayColor);
        return Physics.Raycast(GetComponent<Collider>().transform.position, -Vector3.up, distToGround + 0.5f);
    }

}
