using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public SceneFader sceneFader;

    public string menuScenceName = "MainMenu";


 

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }


    public void Menu()
    {
        sceneFader.FadeTo(menuScenceName);
        Debug.Log("Go to the Menu");
    }

}
