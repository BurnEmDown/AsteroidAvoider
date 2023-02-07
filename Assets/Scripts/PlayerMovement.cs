using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    
    private Camera mainCamera;

    private Vector3 movementDirection;

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

        ProcessInput();
        KeepPlayerOnScreen();
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) return;
        
        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewPortPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewPortPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewPortPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewPortPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }
        
        transform.position = newPosition;
    }
}
