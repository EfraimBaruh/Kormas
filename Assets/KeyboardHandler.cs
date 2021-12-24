using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        if (TouchScreenKeyboard.isSupported)
        {
            if (TouchScreenKeyboard.visible)
            {
                TouchScreenKeyboard.hideInput = true;
            }
        }
        
    }
}
