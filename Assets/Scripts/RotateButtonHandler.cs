using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButtonHandler : ButtonHandler
{

    public override void ToggleButton(bool doSprites)
    {
        if (isOn)
        {
            transform.DOLocalRotate(Vector3.zero, 0.4f);
            AR_Object_Info.instance.CurrentProduct.transform.DOLocalRotate(Vector3.zero, 0.4f);
        }
        else
        {
            transform.DOLocalRotate(Vector3.back * 90f, 0.4f);
            AR_Object_Info.instance.CurrentProduct.transform.DOLocalRotate(Vector3.back * 90f, 0.4f);
        }

        base.ToggleButton(doSprites);
    }
}
