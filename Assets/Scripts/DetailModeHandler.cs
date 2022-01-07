using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum viewState{threeD, augR}
public class DetailModeHandler : MonoBehaviour
{
    [SerializeField] private Sprite threeD, augR;

    [SerializeField] private Image buttonUI;

    public UnityEvent onThreeD, onAR;

    private viewState currentState;

    public void ChangeToThreeD()
    {
        if (currentState != viewState.threeD)
        {
            buttonUI.sprite = threeD;

            StartCoroutine(ChangeView(viewState.threeD));
        }
    }
    
    public void ChangeToAugR()
    {
        if (currentState != viewState.augR)
        {
            buttonUI.sprite = augR;

            StartCoroutine(ChangeView(viewState.augR));
        }
    }

    private IEnumerator ChangeView(viewState state)
    {
        yield return new WaitForSeconds(0.3f);

        switch (state)
        {
            case viewState.threeD:
                onThreeD.Invoke();
                break;
            case viewState.augR:
                onAR.Invoke();
                break;
        }

    }

    private void OnEnable()
    {
        Debug.Log(GameManager.manager.CurrentLevel.LevelID);
        switch (GameManager.manager.CurrentLevel.LevelID)
        {
            case 1:
                currentState = viewState.augR;
                buttonUI.sprite = augR;
                break;
            case 2:
                currentState = viewState.threeD;
                buttonUI.sprite = threeD;
                break;
            default:
                currentState = viewState.augR;
                buttonUI.sprite = augR;
                break;
        }
    }
}
