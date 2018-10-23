using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStare_and_Grab : MonoBehaviour {

    public float secondsToTrigger = 2.0f;
    public Transform VRHand;
    public Rigidbody TargetObject;

    private bool isStaring = false;
    private float secondsStared = 0.0f;

    public void onGazeEnter()
    {
        if (isStaring) {
            return;
        }

        Debug.Log("Started Staring");
        isStaring = true;
        secondsStared = 0.0f;
    }

    public void onGazeExit()
    {
        Debug.Log("Stoped Staring");
        isStaring = false;
    }

    private void Update ()
    {
        if (isStaring) {
            tickStaringTimer();
            maybeGrabObject();
        }
	}

    private void tickStaringTimer()
    {
        secondsStared = secondsStared + Time.deltaTime;
    }

    private void maybeGrabObject()
    {
        if (secondsStared >= secondsToTrigger) {
            GrabObject();
        }
    }

    public void GrabObject()
    {
        TargetObject.transform.parent = VRHand.transform;
        TargetObject.transform.SetPositionAndRotation(new Vector3(TargetObject.transform.parent.position.x+0.75f, TargetObject.transform.parent.position.y+0.18f, TargetObject.transform.parent.position.z+1f), Quaternion.Euler(new Vector3(-15f, 15f, 0f)));
    }
}
