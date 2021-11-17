using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    public GameObject Prefab;
    public float Velocidad;

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
        transform.position += transform.right * Time.deltaTime * Velocidad;
    }
}
