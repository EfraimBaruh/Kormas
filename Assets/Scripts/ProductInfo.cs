using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum category { oto, industry }

public enum voltageType { twelve, tfour }

public enum Animation_State { open, idle }

[System.Serializable]
public class ProductInfo
{
    [SerializeField]
    private int id;

    [SerializeField]
    private string name;

    [SerializeField]
    private string info;

    [SerializeField]
    private category grandCategory;

    [SerializeField]
    private voltageType voltage_Type;

    [SerializeField]
    private Sprite Image;

    [SerializeField]
    private Animator animator;

    private Animation_State animationState = Animation_State.idle;

    public int GetID()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public string GetInfo()
    {
        return info;
    }

    public category GetCategory()
    {
        return grandCategory;
    }

    public voltageType GetVoltageType()
    {
        return voltage_Type;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public Animation_State GetAnimationState()
    {
        return animationState;
    }

    public void SetAnimationState(Animation_State state)
    {
        animationState = state;
    }


    
}
