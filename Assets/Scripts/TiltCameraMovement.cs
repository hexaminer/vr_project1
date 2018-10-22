using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltCameraMovement : MonoBehaviour {

    private static Vector3 k_forward = new Vector3(0, 1, 0);
    private static Vector3 k_backward = new Vector3(0, -1, 0);
    private static Vector3 k_right = new Vector3(-1, 0, 0);
    private static Vector3 k_left = new Vector3(1, 0, 0);

    public float movementSpeed = 5.0f;
    public float pitchThreshold = 30.0f;

    private float pitchInvertThreshold;

    void Start ()
    {
        pitchInvertThreshold = 360 - pitchThreshold;
    }

	void Update ()
    {
        Vector3 movement = new Vector3();

        Debug.Log(pitchAngle());

        if (pitchAngle() >= pitchThreshold && pitchAngle() < 90) {
            movement -= forwardDirection();
        } else if (pitchAngle() <= pitchInvertThreshold && pitchAngle() > 270) {
            movement += forwardDirection();
        }

        movePlayer(movement);
    }

    float pitchAngle()
    {
        return transform.eulerAngles.x;
    }

    void movePlayer(Vector3 direction)
    {
        transform.parent.Translate(direction * movementSpeed * Time.deltaTime);
    }

    Vector3 forwardDirection()
    {
        return new Vector3(transform.forward.x, 0, transform.forward.z);
    }
}
