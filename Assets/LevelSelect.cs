using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string levelToLoad = "MainMenu";

    public void Quit (){
        SceneManager.LoadScene(levelToLoad);
    }
}
