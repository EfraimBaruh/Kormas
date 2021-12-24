using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CalculateDistance : MonoBehaviour
{
    public Transform targetCube;
    void Start()
    {
        float distance = Vector3.Distance(transform.position, targetCube.position);

        Debug.Log(distance);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetCube.position);

        Debug.Log(distance);
    }
}
