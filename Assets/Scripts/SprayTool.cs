using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class SprayTool : MonoBehaviour
{
    ParticleSystem spray;

    private bool sprayAble;

    public UnityEvent onSprayStart, onSprayStop;

    void Start()
    {
        spray = GetComponent<ParticleSystem>();
    }

    public void StartSpray()
    {
        if (!spray.isPlaying && sprayAble)
        {
            spray.Play();

            onSprayStart.Invoke();
        }
        
    }

    public void SetSprayAble()
    {
        sprayAble = true;
    }

    public void StopSpray()
    {
        if (spray.isPlaying)
        {
            spray.Stop();

            sprayAble = false;

            onSprayStop.Invoke();
        }
    }

    [System.Obsolete]
    public void SetSprayColor(Color color)
    {
        spray.startColor = color;

        ParticleSystemRenderer pr = gameObject.GetComponent<ParticleSystemRenderer>();

        pr.material.color = color;
    }
}
