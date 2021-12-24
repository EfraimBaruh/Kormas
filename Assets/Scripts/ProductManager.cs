using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{

    public ProductInfo productInfo;

    public void PlayAnimation()
    {
        productInfo.GetAnimator().SetTrigger("open");
    }

    public void StopAnimation()
    {
        productInfo.GetAnimator().SetTrigger("idle");
    }

    public void ToggleAnimation()
    {
        if(productInfo.GetAnimationState() == Animation_State.open)
        {
            StopAnimation();

            productInfo.SetAnimationState(Animation_State.idle);
        }
        else
        {
            PlayAnimation();

            productInfo.SetAnimationState(Animation_State.open);
        }
    }
}
