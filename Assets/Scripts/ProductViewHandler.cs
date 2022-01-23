using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductViewHandler : MonoBehaviour
{
    private ProductInfo productInfo;
    private void OnEnable()
    {
        productInfo = AR_Object_Info.instance.CurrentProduct.productInfo;

        GameObject viewProduct = Instantiate(productInfo.GetModel(), transform);
    }
    private void OnDisable(){
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
