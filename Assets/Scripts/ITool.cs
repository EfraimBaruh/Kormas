using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITool : MonoBehaviour
{
    public Tool tool;

    public Events.ToolEvent onToolSelect;
    void Start()
    {
        
    }
    public virtual void SelectTool()
    {
        onToolSelect.Invoke(tool);
    }
}
