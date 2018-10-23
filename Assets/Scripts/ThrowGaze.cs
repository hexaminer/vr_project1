using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGaze : Gaze {

    public float force = 1.0f;
    public Camera playerCamera;

    private Rigidbody rigidBody;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

    protected override void onGazeTrigger()
    {
        rigidBody.AddForce(playerCamera.transform.forward * force);
        transform.parent = null;
        rigidBody.isKinematic = false;
        rigidBody.detectCollisions = false;
    }
}
 