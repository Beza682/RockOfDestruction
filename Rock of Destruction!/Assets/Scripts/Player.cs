using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector3 direction;
    public float acceleration;
    private Rigidbody rb;
    private float strength;
    private float size;

    private Vector2 screenPoint;
    private Vector2 deltaScreenPoint;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        strength = 5f;
        direction.z = 1;
        acceleration = 20;
    }

    void FixedUpdate()
    {
        rb.AddForce(direction.normalized * acceleration);
        GameHelper.singleton.distance = transform.position.z;

        //if (Input.GetKey(KeyCode.A))
        //{
        //    direction.x -= 10;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    direction.x += 10;
        //}
        //else
        //{
        //    direction.x = 0;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    acceleration = 60;
        //}
        //else
        //{
        //    acceleration = 20;
        //}
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        deltaScreenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);

        //if (Mathf.Abs(deltaScreenPoint.x - screenPoint.x) > Mathf.Abs(deltaScreenPoint.y - screenPoint.y))
        //{
            if (screenPoint.x < deltaScreenPoint.x && direction.x < 10)
            {
                //direction.x = 3;

                direction.x ++;
            }
            else if (screenPoint.x > deltaScreenPoint.x && direction.x > -10)
            {
                //direction.x = -3;
                direction.x --;
            }
        //}
        //else if (Mathf.Abs(deltaScreenPoint.x - screenPoint.x) < Mathf.Abs(deltaScreenPoint.y - screenPoint.y))
        //{
        //    if (screenPoint.y < deltaScreenPoint.y)
        //    {
        //        acceleration = 60;
        //    }
        //    else if (screenPoint.x > deltaScreenPoint.x)
        //    {
        //        acceleration = 0;
        //    }
        //}
    }

    private void OnMouseUp()
    {
        direction.x = 0;
        acceleration = 20;
    }
}
