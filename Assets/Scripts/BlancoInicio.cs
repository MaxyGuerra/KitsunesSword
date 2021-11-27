using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlancoInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defensa"))
        {
            GameManager.Instance.UpdateWaitingState();
            Destroy(gameObject);

        }
    }
}
