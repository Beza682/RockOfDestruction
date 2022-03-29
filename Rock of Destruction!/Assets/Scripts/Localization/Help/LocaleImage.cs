using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    private string textID; //Идентификатор ресурса, который мы хотим захватить.

    private Image imageComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        imageComponent = GetComponent<Image>();
        //LocalizationManager.instance.LanguageChanged += UpdateLocale;  //Изначальное место поля, перенёс его в Start
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