using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        /*
        if (Touch.activeTouches.Count != 0)
        {
            Vector2 touchPosition = new Vector2();

            foreach (Touch touch in Touch.activeTouches)
            {
                touchPosition += touch.screenPosition;
            }

            touchPosition /= Touch.activeTouches.Count;

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            Debug.Log(worldPosition);
        }
        */

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            
            Debug.Log(worldPosition);
        }
    }
}
