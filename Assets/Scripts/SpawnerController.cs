using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using DG.Tweening;

public class SpawnerController : MonoBehaviour
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    public ARRaycastManager m_RaycastManager;

    private Vector3 initialScale;
    
    void Start()
    {
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        if (m_RaycastManager.Raycast(screenCenter, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            Vector3 smoothedPosiiton = Vector3.Lerp(transform.position, hitPose.position, 0.2f);
            transform.position = smoothedPosiiton;
        }
    }

    public void CloseSpawner()
    {
        Vector3 lastScale = transform.localScale * 1.5f;

        Sequence spawnScaler = DOTween.Sequence();

        spawnScaler.Append(transform.DOScale(lastScale, 0.3f))
            .Append(transform.DOScale(Vector3.zero, 0.3f));
    }

    private void OnDisable()
    {
        transform.localScale = initialScale;
    }
}
