using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStare_and_Grab : MonoBehaviour {
    public float secondsToTrigger = 2.0f;
    public Transform VRHand;

    private Vector3 spearPositionOffset;
    private Vector3 spearEulerRotation;

    private bool isStaring = false;
    private float secondsStared = 0.0f;

    public void Start()
    {
        spearPositionOffset = new Vector3(0.0f, 0.0f, -0.5f);
        spearEulerRotation = new Vector3(0f, 270.0f, 0f);
    }

    public void onGazeEnter()
    {
        isStaring = true;
        secondsStared = 0.0f;
    }

    public void onGazeExit()
    {
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
            Debug.Log("Grabed Object");
        }
    }

    public void GrabObject()
    {
        transform.parent = VRHand.transform;
        Vector3 spearPosition = VRHand.transform.position + spearPositionOffset;
        transform.SetPositionAndRotation(spearPosition, Quaternion.Euler(spearEulerRotation));
    }
}
