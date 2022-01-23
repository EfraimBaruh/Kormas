using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductTransformHandler : MonoBehaviour
{
    [Header("Scale Clampers")]
    [SerializeField] private float Max;
    [SerializeField] private float Min;
    
    float initialFingersDistance ;
    Vector3 initialScale;
    
    Rigidbody m_Rigidbody;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    void LateUpdate()
    {
        if (Input.touchCount == 2)
        {

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            //First set the initial distance between fingers so you can compare.
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(touch1.position, touch2.position);
                initialScale = transform.localScale;
            }
            else
            {
                
                float currentFingersDistance= Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

                float scaleFactor = currentFingersDistance / initialFingersDistance;

                transform.localScale = initialScale * scaleFactor;

                transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, Min, Max), 
                    Mathf.Clamp(transform.localScale.y, Min, Max), 
                    Mathf.Clamp(transform.localScale.z, Min, Max));
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltapos = touch.deltaPosition;

                // if vertical drag angle is greater than 75 deg, dont.
                if (Math.Abs(deltapos.x) > 3f && Mathf.Abs(deltapos.y / deltapos.x) < 3.74f)
                {
                    m_Rigidbody.AddTorque(transform.up * touch.deltaPosition.x * -10);
                }
            }
        }
    }
}
