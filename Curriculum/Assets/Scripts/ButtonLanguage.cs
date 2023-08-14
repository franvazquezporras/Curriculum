using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class ButtonLanguage : MonoBehaviour
{
    private bool active = false;

    [SerializeField] private GameObject languages;
    public void ChangeLocale(int localID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localID));
    }

    IEnumerator SetLocale(int _localID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localID];
        active = false;
        languages.SetActive(false);
    }
}
