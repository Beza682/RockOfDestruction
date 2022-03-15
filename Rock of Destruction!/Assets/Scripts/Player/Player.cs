using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    public float acceleration;
    public float turnAcceleration;
    private Rigidbody rb;

    public float strength;
    public float size;

    private Vector2 screenPoint;
    private Vector2 deltaScreenPoint;


    void Start()
    {
        transform.localScale = transform.localScale * size;
        GameHelper.Instance.playerSize = size;
        //GameHelper.Instance.playerStrength = strength;
        DestructionOfObjects.playerStrength = strength;

        rb = gameObject.GetComponent<Rigidbody>();

        direction.z = 1;
    }

    void FixedUpdate()
    {
        rb.AddForce(direction.normalized * acceleration);
        GameHelper.Instance.distance = transform.position.z;

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        deltaScreenPoint = Camera.main.ViewportToScreenPoint(Input.mousePosition);

        if (screenPoint.x < deltaScreenPoint.x/* && direction.x < 10*/)
        {
            //direction.x += 1;
            direction.x = 1;

            rb.AddForce(Vector3.right * turnAcceleration);
        }
        else if (screenPoint.x > deltaScreenPoint.x/* && direction.x > -10*/)
        {
            //direction.x -= 1;
            direction.x = -1;

            rb.AddForce(Vector3.left * turnAcceleration);
        }
    }

    private void OnMouseUp()
    {
        direction.x = 0;
    }
}
