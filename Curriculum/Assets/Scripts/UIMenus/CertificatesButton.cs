using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CertificatesButton : MonoBehaviour
{
    [SerializeField] private Sprite[] certificate;
    [SerializeField] private CertificateManager certificateManager;
    public void LoadCertificate()
    {
        certificateManager.OpenCertificate(certificate);
    }
}
