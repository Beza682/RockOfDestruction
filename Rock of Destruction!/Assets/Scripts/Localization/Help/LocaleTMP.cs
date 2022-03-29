using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleTMP : MonoBehaviour
{
    [SerializeField]
    private string textID; //Идентификатор ресурса, который мы хотим захватить.

    private TMP_Text textComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        textComponent = GetComponent<TMP_Text>();
        //LocalizationManager.Instance.LanguageChanged += UpdateLocale;  //Изначальное место поля, перенёс его в Start
    }

    private void Start()
    {
        //Убедитесь, что при активации этого объекта отображается правильный язык:
        LocalizationManager.Instance.LanguageChanged += UpdateLocale;

        UpdateLocale();

    }
    /*
    Пытается получить связанный строковый ресурс из LocalizationManager.
    В случае успеха обновляет атрибут text дочернего компонента Text.
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
