using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Positioner
{
    above,
    below
};
public class CanvasPositioner : MonoBehaviour
{
    public Transform target;
    public Positioner positioner;
    public Vector3 offset;
    void Start()
    {
    }

    void Update()
    {
        switch (positioner)
        {
            case Positioner.above:
                transform.position = target.position + offset;
                break;
            case Positioner.below:
                transform.position = target.position - offset;
                break;
        }
    }
}
