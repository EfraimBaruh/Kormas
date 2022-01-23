using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuProductImageSetter : MonoBehaviour
{
    private ProductManager _productManager;
    private Image _image;
    void OnEnable()
    {
        _image = GetComponent<Image>();
        _productManager = transform.GetComponentInParent<ProductManager>();
        
        try
        {
            _image.sprite = _productManager.productInfo.GetImage();
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning("product has no image.");
            throw;
        }

    }
}
