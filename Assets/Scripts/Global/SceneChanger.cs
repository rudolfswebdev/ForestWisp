using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject instructionsPanel = null;
    public void sceneChanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showInstructions()
    {
        if(instructionsPanel)
        {
            instructionsPanel.SetActive(true);
        }
    }

    public void hideInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
