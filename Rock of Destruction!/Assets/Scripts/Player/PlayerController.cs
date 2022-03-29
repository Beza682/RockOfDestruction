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
    private float turn;

    private Vector2 screenPoint;
    private Vector2 deltaScreenPoint;

    private void Awake()
    {
        Instance = this;

        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * acceleration * PlayerCharacteristics.Instance.size);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 30 + PlayerCharacteristics.Instance.size * 10);
        //rb.AddForce(direction.normalized * acceleration * PlayerCharacteristics.Instance.size);
        Debug.Log(rb.velocity.x);
        PlayerMove2();

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
                rb.AddForce(Vector3.right * turnAcceleration * PlayerCharacteristics.Instance.size);

                Debug.Log(acceleration * PlayerCharacteristics.Instance.size);
                Debug.Log(turnAcceleration * PlayerCharacteristics.Instance.size);
            }
            else if (screenPoint.x > deltaScreenPoint.x)
            {
                direction.x = -1;
                rb.AddForce(Vector3.left * turnAcceleration * PlayerCharacteristics.Instance.size);

                Debug.Log(acceleration * PlayerCharacteristics.Instance.size);
                Debug.Log(turnAcceleration * PlayerCharacteristics.Instance.size);

            }
        }
    }   
    private void PlayerMove2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);

        }
        else if (Input.GetMouseButton(0))
        {
            deltaScreenPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            turn = (screenPoint.x - deltaScreenPoint.x) * 3;
            rb.velocity += new Vector3(-turn, 0, 0);

            //if (Mathf.Abs(rb.velocity.x) < 40)
            //{
            //    turn = (screenPoint.x - deltaScreenPoint.x) * 3;
            //    rb.velocity += new Vector3(-turn, 0, 0);
            //}
            //else if (rb.velocity.x > 40)
            //{
            //    rb.velocity = new Vector3(40, rb.velocity.y, rb.velocity.z);
            //}
            //else if (rb.velocity.x < -40)
            //{
            //    rb.velocity = new Vector3(-40, rb.velocity.y, rb.velocity.z);
            //}
            //turn = (screenPoint.x - deltaScreenPoint.x) * 3;
            //transform.position = new Vector3(transform.position.x - turn, transform.position.y, transform.position.z);
            //rb.velocity += new Vector3(- turn, 0, 0);
            //rb.velocity = new Vector3(rb.velocity.x - turn, rb.velocity.y, rb.velocity.z);

            Debug.Log(turn);
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
