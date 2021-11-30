using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    public GameObject Prefab;
    public float Velocidad;

    public bool bCanMove;

    void GameStateChecker()
    {
        switch (GameManager.Instance.gameStates)
        {
            case EGameStates.Waiting:
                bCanMove = false;
                break;
            case EGameStates.Gameplay:
                bCanMove = true;
                break;
            case EGameStates.Pause:
                bCanMove = false;
                break;
            case EGameStates.RoundOver:
                bCanMove = false;
                break;
            case EGameStates.Gameover:
                bCanMove = false;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Defensa"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStateChecker();
        if (bCanMove == true)
        {
            transform.position += transform.right * Time.deltaTime * Velocidad;
        }
    }
}
