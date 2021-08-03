using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;


    public void Play()
    {
        Debug.Log("Play");
        sceneFader.FadeTo(levelToLoad);//另一種寫法FindObjectOfType<SceneFader>().FadeTo(levelToLoad);
    }


    public void Quit()
    {
        Debug.Log("Quit");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }


}
