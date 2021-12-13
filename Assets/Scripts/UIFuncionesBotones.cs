using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFuncionesBotones : MonoBehaviour
{
    public int nextScene;
    public int thisScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(thisScene);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Time.timeScale = 1;
        Application.Quit();
    }
}
