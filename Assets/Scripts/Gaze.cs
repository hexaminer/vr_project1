using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gaze : MonoBehaviour
{
    public float secondsToTrigger = 2.0f;
    public Camera playerCamera;

    private bool isStaring = false;
    private float secondsStared = 0.0f;

    public void onGazeEnter()
    {
        isStaring = true;
        secondsStared = 0.0f;
    }

    public void onGazeExit()
    {
        isStaring = false;
    }

    void Update()
    {
        if (isStaring)
        {
            tickStaringTimer();
            maybeTrigger();
        }
    }

    private void tickStaringTimer()
    {
        secondsStared = secondsStared + Time.deltaTime;
    }

    private void maybeTrigger()
    {
        if (secondsStared >= secondsToTrigger)
        {
            onGazeTrigger();
        }
    }

    protected abstract void onGazeTrigger();
}
