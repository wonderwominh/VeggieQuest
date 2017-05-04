using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateMachineController : MonoBehaviour {
    public Animator stateMachine;
    public int keyCount;
    
	// Use this for initialization
	void Start () {
        stateMachine = GetComponent<Animator>();
        stateMachine.SetBool("has1Key", false);
        keyCount = 0;
        closeDoor();
    }
	
	// Update is called once per frame
	void Update () {
        if (keyCount == 1)
        {
            stateMachine.SetBool("has1Key", true);
        }
    }

    public void openDoor()
    {
        stateMachine.SetBool("playerNearby", true);
    }

    public void closeDoor()
    {
        stateMachine.SetBool("playerNearby", false);
    }
}
