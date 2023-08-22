using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksWeb : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void LinksButton(string link)
    {
        Application.OpenURL(link);
    }
}
