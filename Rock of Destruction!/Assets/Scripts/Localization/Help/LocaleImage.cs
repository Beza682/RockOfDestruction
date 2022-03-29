using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
//������������� ����������� �� ����� ���������� �������������� ����������� ��������� �����������, ����� �� �������������� ������� Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    private string textID; //������������� �������, ������� �� ����� ���������.

    private Image imageComponent;

    private void Awake()
    {
        //������ �� ���:
        imageComponent = GetComponent<Image>();
        //LocalizationManager.instance.LanguageChanged += UpdateLocale;  //����������� ����� ����, ������ ��� � Start
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
            Sprite response = LocalizationManager.Instance.GetImage(textID);
            if (response != null)
                imageComponent.sprite = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}