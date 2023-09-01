using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] private Light lightArea;
    private bool animationInProgress = false;
    private float initialIntensity;
    private float initialRange;
    [SerializeField] private Button[] buttons;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animLinks;
    private void Start()
    {
        if(lightArea != null)
        {
            initialIntensity = lightArea.intensity;
            initialRange = lightArea.range;
        }
    }

    public void OpenArea(string area)
    {
        if (!animationInProgress)
        {
            animationInProgress = true;
            ChangeInteractableButtons();
            switch (area)
            {
                case "studies":
                    StartCoroutine(ChangeLightPropertiesOverTime("Studies"));                    
                    break;
                case "experience":
                    StartCoroutine(ChangeLightPropertiesOverTime("experience"));
                    break;
                case "links":
                    StartCoroutine(ChangeLightPropertiesOverTime("links"));
                    break;
            }
            audioSource.Play();
        }

    }
    private void ChangeInteractableButtons()
    {
        foreach(Button button in buttons)
        {            
            if (button.interactable)
                button.interactable = false;
            else
                button.interactable = true;
        }
    }

    private IEnumerator ChangeLightPropertiesOverTime(string scene)
    {
        if (lightArea == null)
           yield break;
        float duration = 2.0f;
        float startTime = Time.time;
        float targetIntensity = initialIntensity * 50.0f;
        float targetRange = initialRange * 100.0f;
        animLinks.SetBool("exit", true);
        while (Time.time - startTime < duration)
        {
            float elapsedRatio = (Time.time - startTime) / duration;
            lightArea.intensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsedRatio);
            lightArea.range = Mathf.Lerp(initialRange, targetRange, elapsedRatio);
            yield return null;
        }

        lightArea.intensity = targetIntensity;
        lightArea.range = targetRange;
        ChangeInteractableButtons();
        SceneManager.LoadScene(scene);
    }
}