using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 vector3 = new Vector3(0f, 3f, -6f);

    private void Update()
    {
        transform.position = player.transform.position + vector3 * PlayerCharacteristics.Instance.size;
    }
}
