using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStepHandler : MonoBehaviour
{
    public bool isOn;

    public bool isStarted;

    public bool isCompleted;

    public UnityEvent onComplete;

    public virtual void CompleteStep(bool state)
    {
        isCompleted = state;

        if (isCompleted == true)
            onComplete.Invoke();
    }

    public virtual void CompleteStep()
    {
        isCompleted = true;

        onComplete.Invoke();
    }
}
