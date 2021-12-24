using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotater : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Input.touchCount == 2)
        {
            Touch firstFinger = Input.GetTouch(0);

            Touch secondFinger = Input.GetTouch(1);

            if (firstFinger.phase == TouchPhase.Moved || secondFinger.phase == TouchPhase.Moved)
            {
                Vector2 touchPos1 = Input.GetTouch(0).position;

                Vector2 touchPos2 = Input.GetTouch(1).position;
            }
        }
    }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

            touchPosition = default;
            return false;
        }
    }

