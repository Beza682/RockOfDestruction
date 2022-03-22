using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
   
    [Header("Control")]
    [SerializeField] private Vector3 direction;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnAcceleration;
    private Rigidbody rb;

    private Vector2 screenPoint;
    private Vector2 deltaScreenPoint;

    private void Awake()
    {
        Instance = this;

        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {        
        rb.AddForce(direction.normalized * acceleration);
        PlayerMove();
    }
    private void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            direction.x = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaScreenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);

            if (screenPoint.x < deltaScreenPoint.x)
            {
                direction.x = 1;
                rb.AddForce(Vector3.right * turnAcceleration);
            }
            else if (screenPoint.x > deltaScreenPoint.x)
            {
                direction.x = -1;
                rb.AddForce(Vector3.left * turnAcceleration);
            }
        }
    }   


    //void OnMouseDown()
    //{
    //    screenPoint = mainCamera.ScreenToViewportPoint(Input.mousePosition);
    //}


    //void OnMouseDrag()
    //{
    //    deltaScreenPoint = mainCamera.ScreenToViewportPoint(Input.mousePosition);

    //    if (screenPoint.x < deltaScreenPoint.x/* && direction.x < 10*/)
    //    {
    //        //direction.x += 1;
    //        direction.x = 1;

    //        rb.AddForce(Vector3.right * turnAcceleration);
    //    }
    //    else if (screenPoint.x > deltaScreenPoint.x/* && direction.x > -10*/)
    //    {
    //        //direction.x -= 1;
    //        direction.x = -1;

    //        rb.AddForce(Vector3.left * turnAcceleration);
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    direction.x = 0;
    //}
}
