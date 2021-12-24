using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("Button selection Sprites")]
    public Sprite offSprite;
    public Sprite onSprite;

    protected bool isOn;

    protected Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }


    public virtual void ToggleButton()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
    }

    public virtual void ToggleButton(bool doSprites)
    {
        if (isOn)
        {
            image.sprite = offSprite;

            isOn = false;
        }
        else
        {
            image.sprite = onSprite;

            isOn = true;
        }
    }
}
