using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameHelper : MonoBehaviour
{
    public static GameHelper Instance /*{ get; private set; }*/;

    public int score;
    public float distance;


    public TMP_Text simpleScoreTMP;
    public TMP_Text donatScoreTMP;
    public TMP_Text scoreTMP;
    public TMP_Text distanceTMP;

    private int SimpleScore
    {
        get { return Data.Instance.score.simpleScore; }
        set { Data.Instance.score.simpleScore = value; }
    }

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
        simpleScoreTMP.text = SimpleScore.ToString();
    }

    void Update()
    {
        scoreTMP.text = score.ToString();
        distanceTMP.text = Mathf.Round(PlayerController.Instance.gameObject.transform.position.z).ToString();
    }
    //private void OnApplicationFocus(bool focus)
    //{
    //    if (!focus)
    //    {
    //        SimpleScore += score;
    //    }
    //}

    public void IncreaseSimpleScore()
    {
        SimpleScore += score;
    }
}
