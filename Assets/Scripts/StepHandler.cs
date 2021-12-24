using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    [SerializeField]
    private int MaxStepCount;

    public Events.BoolEvent onStart;

    public Events.IntEvent OnStepChange;

    private int currentStep;

    private bool levelInitiated;

    Action onStepChange = delegate { };

    Action onReset = delegate { };

    public int CurrentStep { get { return currentStep; } }

    public void NextStep()
    {
        if (currentStep + 1 <= MaxStepCount)
        {
            currentStep += 1;

            onStepChange.Invoke();

            StepChange();
        }
    }

    public void InitialStep()
    {
        currentStep = 1;

        onStepChange.Invoke();

        levelInitiated = true;

        onStart.Invoke(true);

        StepChange();
    }

    public void PreviousStep()
    {
        if(currentStep - 1 >= 1)
        {
            currentStep -= 1;

            onStepChange.Invoke();

            StepChange();
        }
    }

    public void ResetSteps()
    {
        currentStep = 1;

        onReset.Invoke();
    }

    private void IncreaseStep()
    {
        transform.DOLocalMoveX(transform.localPosition.x - Screen.width, 0.5f);
    }

    private void DecreaseStep()
    {
        transform.DOLocalMoveX(transform.localPosition.x + Screen.width, 0.5f);
    }

    private void ResetStep()
    {
        transform.DOLocalMoveX(-Screen.width, 0.2f);
    }

    private void StepChange()
    {
        OnStepChange.Invoke(currentStep);
    }

    private void OnEnable()
    {
        onStepChange += IncreaseStep;
        onReset += ResetStep;
    }

    private void OnDisable()
    {
        onStepChange -= DecreaseStep;
        onReset -= ResetStep;
    }


}
