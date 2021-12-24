using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [SerializeField]
    private List<GameLevel> gameLevels;

    private GameLevel currentLevel, previousLevel;

    public GameLevel CurrentLevel { get { return currentLevel; } }

    public List<GameLevel> GameLevels { get { return gameLevels; } }

    public Events.GameLevelEvent onGameLevelChange;

    private Action<GameLevel> onLevelChange;

    void Start()
    {
        manager = this;

        currentLevel = gameLevels[0];

        for(int i = 0; i < gameLevels.Count; i++)
        {
            gameLevels[i].LevelID = i;
        }
    }

    public void NextLevel()
    {
        previousLevel = currentLevel;

        currentLevel = gameLevels[gameLevels.IndexOf(currentLevel) + 1];

        onLevelChange.Invoke(currentLevel);
    }

    public void PreviousLevel()
    {
        previousLevel = currentLevel;

        currentLevel = gameLevels[gameLevels.IndexOf(currentLevel) - 1];

        onLevelChange.Invoke(currentLevel);
    }

    public void JumpToLevel(int level_id)
    {
        GameLevel level;
        if (LevelIsValid(level_id, out level))
        {
            previousLevel = currentLevel;

            currentLevel = level;

            onLevelChange.Invoke(currentLevel);
        }
        else
            throw new System.Exception("Called Level is not valid");
    }

    private bool LevelIsValid(int level_id, out GameLevel level)
    {
        level = null;

        if (level_id < gameLevels.Count && level_id >= 0)
        {
            level = gameLevels[level_id];
            return true;
        }
        else
            return false;
    }

    private void OnLevelChanged(GameLevel gameLevel)
    {
        previousLevel.IsOn = false;
        gameLevel.IsOn = true;

        onGameLevelChange.Invoke(gameLevel);

    }

    private void OnEnable()
    {
        onLevelChange += OnLevelChanged;
    }

    private void OnDisable()
    {
        onLevelChange -= OnLevelChanged;
    }
}

[System.Serializable]
public class GameLevel
{

    private int _levelId;

    private bool _started;

    private bool _completed;

    private bool _ison;

    public bool IsStarted { get { return _started; } set { _started = value; } }

    public bool IsCompleted { get { return _completed; } set { _completed = value;  } }

    public bool IsOn { get { return _ison; } set { _ison = value; } }

    public int LevelID { get { return _levelId; } set { _levelId = value; } }
}
