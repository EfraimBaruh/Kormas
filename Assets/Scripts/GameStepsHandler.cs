using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStepsHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> steps;

    void Start()
    {
        // if steps have not initialized
        if(steps.Count < 1)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                steps.Add(transform.GetChild(i).gameObject);
            }
        }

        // set initial step
      //  SetStep(0);
    }

    public void ChangeStep(GameLevel gameLevel)
    {
        if (GameManager.manager.GameLevels.Contains(gameLevel))
        {
            int stepIndex = GameManager.manager.GameLevels.IndexOf(gameLevel);

            SetStep(stepIndex);
        }
    }

    public void SetStep(int stepIndex)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == stepIndex)
                steps[i].SetActive(true);
            else
                steps[i].SetActive(false);
        }
    }

    public void ResetData()
    {
        SetStep(0);
    }
}
