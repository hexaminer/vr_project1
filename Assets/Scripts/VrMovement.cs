using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

    public float speed = 1;

    private Vector3 _endPosition;
    private Vector3 _startPosition;
    private bool _isMoving = false;
    private float _startTime;
    private float _travelDistance;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_isMoving)
        {
            interpolatePosition();
        }
	}

    private void interpolatePosition()
    {
        float progressDistance = (Time.time - _startTime) * speed;
        float percentCompleted = progressDistance / _travelDistance;
        transform.position = Vector3.Lerp(_startPosition, _endPosition, percentCompleted);

        if (percentCompleted >= 1)
        {
            _isMoving = false;
        }
    }

    public void moveTo(Transform newTransform)
    {
        if (!_isMoving)
        {
            _startPosition = this.transform.position;
            _endPosition = new Vector3(newTransform.position.x, this.transform.position.y, newTransform.position.z);
            _startTime = Time.time;
            _travelDistance = Vector3.Distance(_startPosition, _endPosition);
            _isMoving = true;
        }
    }
}
