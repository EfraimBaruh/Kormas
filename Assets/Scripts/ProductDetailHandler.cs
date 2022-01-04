using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetailHandler : MonoBehaviour
{
    ProductInfo currentProduct;

    public static ProductDetailHandler instance;
    
    [SerializeField] private Image productImage;
    [SerializeField] private TextMeshProUGUI product_exp;
    
    public Action<ProductManager> onSelect = delegate {  };
    public Action onDeselect = delegate { };

    [SerializeField]
    private float speed;

    #region product detail transform info
    
    [SerializeField]
    private Vector3 targetPos;

    [SerializeField]
    private Vector3 targetScale;

    #endregion

    #region inital product transform info
    private Vector3 initialPos, initialScale;
    private bool initialized;
    #endregion

    private void Awake()
    {
        initialScale = transform.localScale;
        
        transform.localScale = Vector3.zero;

        instance = this;
    }

    void Start()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        targetPos = new Vector3(screenCenter.x, screenCenter.y, 0);
        
    }

    public void SetCurrentProduct(ProductManager productManager)
    {
        currentProduct = productManager.productInfo;

        // get initial pos and scale of selected product
        initialPos = productManager.transform.position;
        initialized = true;

        // get start point and scale for the product detail panel
        transform.position = productManager.transform.position;
        transform.localScale = initialScale;

        productImage.sprite = productManager.productInfo.GetImage();
        product_exp.text = productManager.productInfo.GetExp();
        onSelect.Invoke(productManager);

        // set gif for gif player from currentProduct
    }

    public void DeselectCurrentProduct()
    {
        currentProduct = null;

        onDeselect.Invoke();
    }

    private void SelectProduct(ProductManager manager)
    {
        transform.DOMove(targetPos, speed);
        transform.DOScale(targetScale, speed);
    }

    private void DeselectProduct()
    {
        if (initialized)
        {
            transform.DOMove(initialPos, speed);
            transform.DOScale(Vector3.zero, speed);

            initialized = false;
        }
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
