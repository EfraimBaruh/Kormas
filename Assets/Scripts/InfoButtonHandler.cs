using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InfoButtonHandler : ButtonHandler
{
    [Header("Info Button Variables")]
    public GameObject infoCanvas;

    public float infoCanvasScale;

    public VerticalLayoutGroup sideMenu;

    public GameObject selectionParent;

    public override void ToggleButton()
    {

        if (isOn)
        {
            infoCanvas.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() =>
            {
                image.sprite = offSprite;

                transform.SetParent(sideMenu.transform);

                transform.SetAsFirstSibling();

                sideMenu.enabled = true;

                selectionParent.SetActive(false);

                isOn = false;

            });
            
        }

        else
        {
            infoCanvas.transform.DOScale(infoCanvasScale, 0.3f).OnComplete(() =>
            {
                image.sprite = onSprite;

                sideMenu.enabled = false;

                selectionParent.SetActive(true);
                transform.SetParent(selectionParent.transform);

                isOn = true;

            });
        }
    }
}
