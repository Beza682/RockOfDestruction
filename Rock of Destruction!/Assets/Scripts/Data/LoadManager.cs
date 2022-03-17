using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private void Awake()
    {
        Data.Instance = SaveController.Load<Data>();

        //DontDestroyOnLoad(gameObject);    // �� �� ������������ ���� ����� � ������� SaveManager
        SceneManager.LoadScene("GameScene");
    }
    //private void OnApplicationFocus(bool focus)
    //{
    //    if (!focus)
    //    {
    //        SaveController.Save(Data.Instance);
    //    }
    //}
}
