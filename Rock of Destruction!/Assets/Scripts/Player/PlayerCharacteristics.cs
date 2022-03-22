using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public static PlayerCharacteristics Instance;

    public float strength;
    public float size;

    private void Awake()
    {
        Instance = this;
        transform.localScale = transform.localScale * size;

    }
    void Start()
    {

    }
}