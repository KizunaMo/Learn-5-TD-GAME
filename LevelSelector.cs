using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;


    public void Selecte(string levelname)
    {
        
        fader.FadeTo(levelname);
        

    }

}
