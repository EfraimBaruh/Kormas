using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateButtonHandler : ButtonHandler
{

    public void DoAnimate()
    {
        try
        {
            switch (AR_Object_Info.instance.CurrentProduct.productInfo.GetAnimationState())
            {
                case Animation_State.idle:
                case Animation_State.open:
                    ToggleButton(true);
                    break;
            }

            AR_Object_Info.instance.CurrentProduct.ToggleAnimation();

        }
        catch
        {
            throw new System.Exception(message: "error in toggling product animation.");
        }
    }
}
