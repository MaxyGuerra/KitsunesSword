using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIVictoria;
    public GameObject UIDerrota;
    public GameObject UIPausa;

    // Start is called before the first frame update
    void Start()
    {
        UIVictoria.SetActive(false);
        UIDerrota.SetActive(false);
        UIPausa.SetActive(false);
    }

    void GameStateChecker()
    {
        switch (GameManager.Instance.gameStates)
        {
            case EGameStates.Waiting:
                break;
            case EGameStates.Gameplay:
                UIVictoria.SetActive(false);
                UIDerrota.SetActive(false);
                UIPausa.SetActive(false);
                break;
            case EGameStates.Pause:
                UIVictoria.SetActive(false);
                UIDerrota.SetActive(false);
                UIPausa.SetActive(true);
                break;
            case EGameStates.RoundOver:
                UIVictoria.SetActive(true);
                UIDerrota.SetActive(false);
                UIPausa.SetActive(false);
                break;
            case EGameStates.Gameover:
                UIVictoria.SetActive(false);
                UIDerrota.SetActive(true);
                UIPausa.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStateChecker();
    }
}
