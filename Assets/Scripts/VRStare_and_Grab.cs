using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStare_and_Grab : Gaze
{
    public Transform VRHand;

    private Vector3 spearPositionOffset;
    private Vector3 spearEulerRotation;

    public void Start()
    {
        spearPositionOffset = new Vector3(0.0f, 0.0f, -0.5f);
        spearEulerRotation = new Vector3(0f, 270.0f, 0f);
    }

    protected override void onGazeTrigger()
    {
        GrabObject();
    }

    public void GrabObject()
    {
        transform.parent = VRHand.transform;
        Vector3 spearPosition = VRHand.transform.position + spearPositionOffset;
        transform.SetPositionAndRotation(spearPosition, Quaternion.Euler(spearEulerRotation));
    }
}
