using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuProductTextSetter : MonoBehaviour
{
    private ProductManager _productManager;
    private Text _proName;
    void OnEnable()
    {
        _proName = GetComponent<Text>();
        _productManager = transform.GetComponentInParent<ProductManager>();
        
        try
        {
            _proName.text = _productManager.productInfo.GetName();
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning("product has no name.");
            throw;
        }

    }
}
