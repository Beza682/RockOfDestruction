using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
//������������� ����������� �� ����� ���������� �������������� ����������� ��������� �����������, ����� �� �������������� ������� Locale.
public class LocaleTMP : MonoBehaviour
{
    [SerializeField]
    private string textID; //������������� �������, ������� �� ����� ���������.

    private TMP_Text textComponent;

    private void Awake()
    {
        //������ �� ���:
        textComponent = GetComponent<TMP_Text>();
        //LocalizationManager.Instance.LanguageChanged += UpdateLocale;  //����������� ����� ����, ������ ��� � Start
    }

    private void Start()
    {
        //���������, ��� ��� ��������� ����� ������� ������������ ���������� ����:
        LocalizationManager.Instance.LanguageChanged += UpdateLocale;

        UpdateLocale();

    }
    /*
    �������� �������� ��������� ��������� ������ �� LocalizationManager.
    � ������ ������ ��������� ������� text ��������� ���������� Text.
    */
    public void UpdateLocale()
    {
        try
        {
            string response = LocalizationManager.Instance.GetText(textID);
            if (!string.IsNullOrEmpty(response))
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}
