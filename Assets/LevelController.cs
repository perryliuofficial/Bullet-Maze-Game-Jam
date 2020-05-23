using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public string levelToLoad = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
