using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenBlurHandler : MonoBehaviour
{
    private bool _isActive;

    [SerializeField] private GameObject blurPanel;
    
    public  bool IsActive
    {
        get { return _isActive; }
    }

    public UnityEvent onActivate, onDeactivate;
    private void Awake()
    {
        DeActivate();
    }

    void Start()
    {
        
    }

    public void Activate(ProductManager manager)
    {
        blurPanel.SetActive(true);

        _isActive = true;
        
        onActivate.Invoke();
    }

    public void DeActivate()
    {
        blurPanel.SetActive(false);

        _isActive = false;
        
        onDeactivate.Invoke();
    }

    private void OnEnable()
    {
        FindObjectOfType<ProductDetailHandler>().onSelect += Activate;
    }

    private void OnDisable()
    {
        FindObjectOfType<ProductDetailHandler>().onSelect -= Activate;
    }
}
