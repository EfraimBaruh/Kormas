using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductDetailHandler : MonoBehaviour
{
    ProductInfo currentProduct;

    public Action onSelect, onDeselect;

    [SerializeField]
    private Vector3 targetPos;

    [SerializeField]
    private Vector3 targetScale;

    [SerializeField]
    private float speed;

    private Vector3 initialPos, initialScale;

    void Start()
    {
        
    }

    public void SetCurrentProduct(ProductManager productManager)
    {
        currentProduct = productManager.productInfo;

        // get initial pos and scale of selected product
        initialPos = productManager.transform.position;
        initialScale = productManager.transform.localScale;

        // get start point and scale for the product detail panel
        transform.position = productManager.transform.position;
        transform.localScale = productManager.transform.localScale;

        onSelect.Invoke();

        // set gif for gif player from currentProduct
    }

    public void DeselectCurrentProduct()
    {
        currentProduct = null;

        onDeselect.Invoke();
    }

    private void SelectProduct()
    {
        transform.DOLocalMove(targetPos, speed);
        transform.DOScale(targetScale, speed);
    }

    private void DeselectProduct()
    {
        transform.DOLocalMove(initialPos, speed);
        transform.DOScale(initialScale, speed);
    }

    private void OnEnable()
    {
        onSelect += SelectProduct;
        onDeselect += DeselectProduct;
    }

    private void OnDisable()
    {
        onSelect -= SelectProduct;
        onDeselect -= DeselectProduct;
    }
}
