using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Tool {info, scale, animate, rotate, none}
public class ToolSelection : MonoBehaviour
{
    public static ToolSelection instance;

    private Tool currentTool;

    public Events.Vector2Event onInfo, onScale, onAnimate, onRotate, onRotateStop, onInfoStop, onScaleStop, onAnimateStop;

    private void Start()
    {
        instance = this;

        SelectTool(Tool.none);
    }

    public void SelectTool(Tool tool)
    {
        currentTool = tool;
    }

    public void DoNothing()
    {

    }
    public void OnAction(Vector2 touch_position)
    {
        switch (currentTool)
        {
            case Tool.info:
                onInfo.Invoke(touch_position);
                break;
            case Tool.scale:
                onScale.Invoke(touch_position);
                break;
            case Tool.animate:
                onAnimate.Invoke(touch_position);
                break;
            case Tool.rotate:
                onRotate.Invoke(touch_position);
                break;
        }
    }

    public void onActionStop(Vector2 touch_position)
    {
        switch (currentTool)
        {
            case Tool.info:
                onInfoStop.Invoke(touch_position);
                break;
            case Tool.scale:
                onScaleStop.Invoke(touch_position);
                break;
            case Tool.animate:
                onScaleStop.Invoke(touch_position);
                break;
            case Tool.rotate:
                onRotateStop.Invoke(touch_position);
                break;
        }
    }
}
