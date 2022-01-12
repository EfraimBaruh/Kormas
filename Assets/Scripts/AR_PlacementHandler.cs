using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_PlacementHandler : MonoBehaviour
{
    private GameObject currentModel;

    public AR_Object_Placer placer;

    public void SetCurrentModel()
    {
        ProductInfo productInfo = AR_Object_Info.instance.SelectedProduct.productInfo;

        currentModel = productInfo.GetModel();
        try
        {
            placer.placedPrefab = currentModel;
            
            AR_Object_Info.instance.SetCurrentModel(currentModel);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("missing model for product");
        }
        placer.placedPrefab.GetComponent<ProductManager>().productInfo = productInfo;
    }
}
