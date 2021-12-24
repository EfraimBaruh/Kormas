using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Object_Info : MonoBehaviour
{
    public static AR_Object_Info instance;

    private ProductManager currentProduct;

    public ProductManager CurrentProduct { get { return currentProduct; } }

    private void Start()
    {
        instance = this;
    }

    public void SetCurrentModel(GameObject model)
    {
        try
        {
            currentProduct = model.GetComponent<ProductManager>();
        }
        catch
        {
            throw new System.Exception(message: "product prefab doesnt has manager");
        }
    }

}
