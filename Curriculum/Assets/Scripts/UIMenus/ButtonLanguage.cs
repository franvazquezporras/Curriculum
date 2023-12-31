using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class ButtonLanguage : MonoBehaviour
{
    private bool active = false;

    [SerializeField] private GameObject languages;
    [SerializeField] private GameObject blockPanel;

    private void Start()
    {
        SystemLanguage currentLanguage = Application.systemLanguage;
        if(currentLanguage == SystemLanguage.Spanish)
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        else
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
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
        blockPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
        
    }
}
