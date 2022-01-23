using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraHandler : MonoBehaviour
{
    [Header("Rotation Clampers")] 
    [SerializeField] private float rMax;
    [SerializeField] private float rMin;
    
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 300, 0);
    }
    void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltapos = touch.deltaPosition;

                // if vertical drag angle is greater than 75 deg, dont.
                if (Math.Abs(deltapos.y) > 3f && Mathf.Abs(deltapos.x / deltapos.y) < 3.74f)
                {
                    m_Rigidbody.AddTorque(transform.right * touch.deltaPosition.y * -2);
                }
            }
        }
        
        Vector3 currentRot = transform.localRotation.eulerAngles;

        if (currentRot.x < 180)
        {
            currentRot.x = Mathf.Clamp(currentRot.x, 0, rMax);
        }
        else
        {
            currentRot.x = Mathf.Clamp(currentRot.x, 360 + rMin, 360);
        }
        transform.localEulerAngles = currentRot;
    }
}
