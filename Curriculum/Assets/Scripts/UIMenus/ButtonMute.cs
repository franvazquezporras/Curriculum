using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonMute : MonoBehaviour
{

    [SerializeField] private Sprite onButton;
    [SerializeField] private Sprite offButton;
    public AudioMixer audioMixer;
    
    private bool isMusicMuted;
    private bool isSoundMuted;

    private void Awake()
    {
        isMusicMuted = PlayerPrefs.GetInt("musicMuted", 0) == 1;
        isSoundMuted = PlayerPrefs.GetInt("soundMuted", 0) == 1;
    }

    private void Start()
    {
        if (gameObject.name == "BMusic")
        {
            GetComponent<Image>().sprite = isMusicMuted ? offButton : onButton;
            audioMixer.SetFloat("music", PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            GetComponent<Image>().sprite = isSoundMuted ? offButton : onButton;
            audioMixer.SetFloat("sound", PlayerPrefs.GetFloat("soundVolume"));
        }
    }
    public void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;
        SetAudioMutedState("music", isMusicMuted);
        GetComponent<Image>().sprite = isMusicMuted ? offButton : onButton;
    }

    public void ToggleSound()
    {
        isSoundMuted = !isSoundMuted;
        SetAudioMutedState("sound", isSoundMuted);
        GetComponent<Image>().sprite = isSoundMuted ? offButton : onButton;
    }

    private void SetAudioMutedState(string parameterName, bool isMuted)
    {        
        float volume = isMuted ? -80f : 0f;
        audioMixer.SetFloat(parameterName, volume);
        PlayerPrefs.SetInt(parameterName + "Muted", isMuted ? 1 : 0);
        PlayerPrefs.SetFloat(parameterName + "Volume", volume);
        PlayerPrefs.Save();         
    }

}
