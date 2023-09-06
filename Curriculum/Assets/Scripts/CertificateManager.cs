using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CertificateManager : MonoBehaviour
{    
    private List<Sprite> certificateSprites; //lista que se muestra
    [SerializeField] private Image certificateSprite;//imagen donde se muestra 1 a 1
    [SerializeField] private GameObject certificatePanel; //panel
    [SerializeField] private GameObject rightButton;//boton siguiente
    [SerializeField] private GameObject leftButton; //boton anterior
    private int selectedOption;

    private void Start()
    {
        certificateSprites = new List<Sprite>();
    }
    public void OpenCertificate(Sprite[] _certificates )
    {
        selectedOption = 0;
        certificateSprite.sprite = null;
        certificateSprites.Clear(); //limpia la lista que se muestra
        foreach (Sprite sprite in _certificates)
            certificateSprites.Add(sprite); //genera la lista con los sprites del boton        
        certificatePanel.SetActive(true); //activa el panel
        if (_certificates.Length > 1) //activa o desactiva los botones anterior y siguiente
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
        else
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
        UpdateCertificate(selectedOption); //carga la primera imagen
    }
    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= certificateSprites.Count) 
            selectedOption = 0;
        UpdateCertificate(selectedOption);
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)        
            selectedOption = certificateSprites.Count - 1;
        
        UpdateCertificate(selectedOption);
    }
    private void UpdateCertificate(int _selectedOption)
    {
        Sprite certificate = certificateSprites[_selectedOption];       
        certificateSprite.sprite = certificate;
    }
}
