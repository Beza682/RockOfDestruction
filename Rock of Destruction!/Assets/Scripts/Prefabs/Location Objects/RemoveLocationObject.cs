using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLocationObject : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.position.z < (PlayerController.Instance.gameObject.transform.position.z - 200))
        {
            Destroy(gameObject);
        }
    }
}
