using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] private GameObject item;
  
    public void OpenArea(string area)
    {
        switch (area)
        {
            case "studies":
                LoadNewScene("Studies");
                break;
            case "experience":
                LoadNewScene("Experience");
                break;
            case "links":
                LoadInThisScene(item);
                break;
        }
    }


    private void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadInThisScene(GameObject itemToLoad)
    {
        itemToLoad.SetActive(true);
    }

}
