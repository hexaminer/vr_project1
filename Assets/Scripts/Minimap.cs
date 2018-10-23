using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform playerTrabsform;

    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */

    void LateUpdate()
    {
        Vector3 newPosition = playerTrabsform.position;
        newPosition.y = 90f;//playerTrabsform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, playerTrabsform.eulerAngles.y, 0f);

    }
}