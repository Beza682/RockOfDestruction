using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Awake()
    {
        Data.Instance = SaveController.Load<Data>();

        if (Data.Instance == null)
        {
            Data.Instance = new Data();
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GameScene");
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveController.Save(Data.Instance);
        }
    }
}
