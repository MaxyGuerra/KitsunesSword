using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFuncionesBotones : MonoBehaviour
{
    public int nextScene;
    public int thisScene;
    public bool bHaveAnim;
    public GameObject Puertas;
    Animator animPuertas;

    private void Awake()
    {
        animPuertas = Puertas.GetComponent<Animator>();
    }
    public void NextScene()
    {
        if(bHaveAnim == true)
        {
            animPuertas.Play("CerrarPuertas");
            Debug.Log("si anim");
            StartCoroutine("PlayAnim");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(2f);
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
