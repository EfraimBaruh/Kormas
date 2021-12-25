using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Object_Info : MonoBehaviour
{
    public static AR_Object_Info instance;

    private ProductManager _currentProduct, _selectedProduct;

    public ProductManager CurrentProduct
    {
        get { return _currentProduct; }
    }
    public  ProductManager SelectedProduct
    {
        get { return _selectedProduct; }
    }

    private void Start()
    {
        instance = this;
    }

    public void SetCurrentModel(GameObject model)
    {
        try
        {
            _currentProduct = model.GetComponent<ProductManager>();
        }
        catch
        {
            throw new System.Exception(message: "product prefab doesnt has manager");
        }
    }

    public void SetSelectedProduct(ProductManager productManager)
    {
        _selectedProduct = productManager;
    }

    public void UnsetSelectedProduct()
    {
        _selectedProduct = null;
    }

    private void OnEnable()
    {
        FindObjectOfType<ProductDetailHandler>().onSelect += SetSelectedProduct;
        FindObjectOfType<ProductDetailHandler>().onDeselect += UnsetSelectedProduct;
    }

    private void OnDisable()
    {
        FindObjectOfType<ProductDetailHandler>().onSelect -= SetSelectedProduct;
        FindObjectOfType<ProductDetailHandler>().onDeselect -= UnsetSelectedProduct;
    }
}
