using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int turnLeftState;
    public int turnRightState;
    public int walkState;
    public int walkBackState;
    public int walkTurnLeftState;
    public int walkTurnRightState;
    public int runState;
    public int runTurnLeftState;
    public int runTurnRightState;
    public int invisibleState;
    public int jumpState;
    public int jumpBool;
    public int sprintingBool; 
    public int safeBool;
    public int groundedBool; 
    public int speedFloat;
    public int turningInt;  

    private void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        deadBool = Animator.StringToHash("Dead");
        turnLeftState = Animator.StringToHash("TurnLeftWalk");
        turnRightState = Animator.StringToHash("TurnRightWalk");
        walkState = Animator.StringToHash("Walking");
        walkBackState = Animator.StringToHash("WalkBack");
        walkTurnLeftState = Animator.StringToHash("TurnLeftWalk");
        walkTurnRightState = Animator.StringToHash("TurnRightWalk");
        runState = Animator.StringToHash("Running");
        runTurnLeftState = Animator.StringToHash("TurnLeftRun");
        runTurnRightState = Animator.StringToHash("TurnRightRun");
        invisibleState = Animator.StringToHash("Invisible.Invisible");
        jumpState = Animator.StringToHash("Jumping");
        jumpBool = Animator.StringToHash("Jump");
        groundedBool = Animator.StringToHash("Grounded");
        sprintingBool = Animator.StringToHash("Sprint");
        safeBool = Animator.StringToHash("Safe");
        speedFloat = Animator.StringToHash("Speed");
        turningInt = Animator.StringToHash("Turning"); 
        
    }
}
