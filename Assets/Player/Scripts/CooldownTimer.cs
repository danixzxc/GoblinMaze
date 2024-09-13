using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CooldownTimer : MonoBehaviour
{

    public float waitTime = 1.0f;
    public float timeLeft = 0.0f;
    public bool paused = false;

    public UnityEvent onAble;
    

    void Update()
    {
        if (!paused)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                timeLeft = 0.0f;
                onAble.Invoke();
            }
        }
    }

    public bool IsAble()
    {
        return timeLeft <= 0.0f;
    }

    public bool Activate()
    {
        if (IsAble())
        {
            timeLeft = waitTime;
            return true;
        }
        else { return false; }
    }
}
