using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void sceneChanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
