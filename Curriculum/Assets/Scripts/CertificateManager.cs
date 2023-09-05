using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CertificateManager : MonoBehaviour
{
    [SerializeField] private Sprite [] certificateSprites;
    [SerializeField] private Image certificateSprite;
    [SerializeField] private GameObject certificatePanel;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject leftButton;
    private int selectedOption = 0;



    public void OpenCertificate()
    {
        certificatePanel.SetActive(true);
        if (certificateSprites.Length > 1)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
        UpdateCertificate(selectedOption);
    }
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= certificateSprites.Length) { 
            selectedOption = 0;
        }
        UpdateCertificate(selectedOption);
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = certificateSprites.Length - 1;
        }
        UpdateCertificate(selectedOption);
    }
    private void UpdateCertificate(int _selectedOption)
    {
        Sprite certificate = certificateSprites[_selectedOption];
        certificateSprite.sprite = certificate;
    }
}
