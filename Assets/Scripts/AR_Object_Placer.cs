using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using DG.Tweening;

[RequireComponent(typeof(ARRaycastManager))]
public class AR_Object_Placer : MonoBehaviour
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
    
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;
    
    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }
    
    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    private bool _spawnAble = true;
    
    public Events.GameObjectEvent onPlaceModel; 
    
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }
    void Start()
    {
        
    }

    public void DoSpawn(Vector2 touchPos)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
            return;
        
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        if (m_RaycastManager.Raycast(screenCenter, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {

                spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation, transform);
                // set initial rotation to zero
                spawnedObject.transform.localEulerAngles = Vector3.zero;

                float scale_y = spawnedObject.transform.localScale.y;

                spawnedObject.transform.localScale = new Vector3(spawnedObject.transform.localScale.x, 0,
                    spawnedObject.transform.localScale.z);
                
                onPlaceModel.Invoke(spawnedObject);
                
                spawnedObject.transform.DOScaleY(scale_y, 0.3f).OnComplete(() =>
                {
                    onPlaceModel.Invoke(spawnedObject);
                    _spawnAble = false;
                });
            }
        }
    }

    private void OnEnable()
    {
        _spawnAble = true;
    }

    private void OnDisable()
    {
        Destroy(spawnedObject);

        _spawnAble = false;
    }
}
