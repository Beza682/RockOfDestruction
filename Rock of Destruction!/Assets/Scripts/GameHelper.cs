using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameHelper : MonoBehaviour
{
    public static GameHelper Instance { get; private set; }

    public GameObject player;

    public float score;
    public float distance;

    public float playerSize;
    public float playerStrength;

    public List<GameObject> destructibleObjects;


    public TextMesh textMesh;
    public Text scoreText;
    public Text distanceText;

    private Vector3 vector3 = new Vector3(0f, 3f, -6f);

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + vector3 * playerSize;
        scoreText.text = $"Score: {score}";
        distanceText.text = $"Distance: {Mathf.Round(distance)}";

    }
}
