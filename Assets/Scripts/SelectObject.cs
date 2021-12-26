using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectionType{gameobject, general}
public class SelectObject : MonoBehaviour
{
    public SelectionType selectionType;
    
    public Events.Vector2Event onTouchMove, onTouchBegan, onTouchEnd, onTouchStationary;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 position = Vector3.zero;

            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit hit = new RaycastHit();
            // Create a particle if hit
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitpoint = hit.point;

                if (selectionType == SelectionType.gameobject)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                onTouchBegan.Invoke(touch.position);
                                break;
                            case TouchPhase.Moved:
                                onTouchMove.Invoke(touch.position);
                                break;
                            case TouchPhase.Ended:
                                onTouchEnd.Invoke(touch.position);
                                break;
                            case TouchPhase.Stationary:
                                onTouchStationary.Invoke(touch.position);
                                break;
                        }
                    }
                }
                else
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            onTouchBegan.Invoke(touch.position);
                            break;
                        case TouchPhase.Moved:
                            onTouchMove.Invoke(touch.position);
                            break;
                        case TouchPhase.Ended:
                            onTouchEnd.Invoke(touch.position);
                            break;
                        case TouchPhase.Stationary:
                            onTouchStationary.Invoke(touch.position);
                            break;
                    }
                }
            }
            
        }
    }
}
