using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameHelper : MonoBehaviour
{
    public static GameHelper Instance { get; private set; }

    public GameObject player;

    public float score;
    public float distance;

    public float playerSize;
    public float playerStrength;

    public List<GameObject> destructibleObjects;


    public TMP_Text scoreTMP;
    public TMP_Text distanceTMP;

    private Vector3 vector3 = new Vector3(0f, 3f, -6f);

    private void Awake()
    {
        Instance = this;

        //if (!Instance)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + vector3 * playerSize;
        scoreTMP.text = score.ToString();
        distanceTMP.text = Mathf.Round(distance).ToString();
    }
}
