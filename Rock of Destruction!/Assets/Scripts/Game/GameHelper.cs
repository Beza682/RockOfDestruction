using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameHelper : MonoBehaviour
{
    public static GameHelper Instance /*{ get; private set; }*/;

    [HideInInspector] public int score;
    internal float distance;

    public TMP_Text simpleScoreTMP;
    public TMP_Text donatScoreTMP;

    [SerializeField] private TMP_Text scoreTMP;
    [SerializeField] private TMP_Text distanceTMP;

    private float SimpleScore
    {
        get { return Data.Instance.score.simpleScore; }
        set { Data.Instance.score.simpleScore = value; }
    }   
    private float DonatScore
    {
        get { return Data.Instance.score.donatScore; }
        set { Data.Instance.score.donatScore = value; }
    }

    private void Awake()
    {
        Instance = this;

        simpleScoreTMP.text = SimpleScore.ToString();
        donatScoreTMP.text = DonatScore.ToString();

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

    void Update()
    {
        scoreTMP.text = score.ToString();
        distanceTMP.text = Mathf.Round(PlayerController.Instance.gameObject.transform.position.z).ToString();
    }

    public void IncreaseSimpleScore()
    {
        SimpleScore += score;
    }

}
