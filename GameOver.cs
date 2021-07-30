using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roindsText;

    public SceneFader sceneFader;

    public string menuScenceName = "MainMenu";


    private void OnEnable()
    {
        roindsText.text = PlayerStats.rounds.ToString();
    }

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
