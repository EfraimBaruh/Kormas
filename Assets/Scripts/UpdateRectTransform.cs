using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRectTransform : MonoBehaviour
{
    [SerializeField] private RectTransform content;

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, content.sizeDelta.y);
    }
}
