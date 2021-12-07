using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    public delegate void FEventosPuntos();
    public static event FEventosPuntos OnEventosPuntos;

    public float velocidad;

    public bool bCanMove;

    public GameObject prefabComplemento;
    public GameObject complemento;
    public Complemento complementoScript;

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

    public void AnnadirComplemento()
    {
        complemento = Instantiate(prefabComplemento, (transform.position + new Vector3(0,0,-0.2f)), Quaternion.identity);
        complemento.transform.parent = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Defensa"))
        {
            complemento.transform.parent = null;
            complementoScript = complemento.GetComponent<Complemento>();
            complementoScript.HacerSonido();
            OnEventosPuntos?.Invoke();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStateChecker();
        if (bCanMove == true)
        {
            transform.position += transform.right * Time.deltaTime * velocidad;
        }
    }
}
