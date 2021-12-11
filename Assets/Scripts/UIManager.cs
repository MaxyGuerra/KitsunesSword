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
        
    }

    void GameStateChecker()
    {
        switch (GameManager.Instance.gameStates)
        {
            case EGameStates.Waiting:
                break;
            case EGameStates.Gameplay:
                break;
            case EGameStates.Pause:
                break;
            case EGameStates.RoundOver:
                break;
            case EGameStates.Gameover:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStateChecker();
    }
}
