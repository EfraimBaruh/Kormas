using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductListController : MonoBehaviour
{
    private List<ProductInfo> product_List = new List<ProductInfo>();
    
    public List<ProductInfo> ProductInfos
    {
        get { return product_List; }
    }
    void Start()
    {
        ProductManager[] productManagers = transform.GetComponentsInChildren<ProductManager>();

        foreach (ProductManager productManager in productManagers)
        {
            product_List.Add(productManager.productInfo);
        }
    }

}
