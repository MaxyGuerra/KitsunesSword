using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensaPoints : MonoBehaviour
{
    public GameObject DefensaDerechaAlta;
    public GameObject DefensaIzquierdaAlta;
    public GameObject DefensaDerechaMedia;
    public GameObject DefensaIzquierdaMedia;
    public GameObject DefensaDerechaBaja;
    public GameObject DefensaIzquierdaBaja;

    // Start is called before the first frame update
    void Start()
    {
        DefensaDerechaAlta.SetActive(false);
        DefensaIzquierdaAlta.SetActive(false);
        DefensaDerechaMedia.SetActive(false);
        DefensaIzquierdaMedia.SetActive(false);
        DefensaDerechaBaja.SetActive(false);
        DefensaIzquierdaBaja.SetActive(false);
    }

    void InputDefensa()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            DefensaDerechaAlta.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            DefensaIzquierdaAlta.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            DefensaDerechaMedia.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            DefensaIzquierdaMedia.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            DefensaDerechaBaja.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            DefensaIzquierdaBaja.SetActive(true);
            StartCoroutine("TurnOffCajas");
        }
    }

    IEnumerator TurnOffCajas()
    {
        yield return new WaitForSeconds(0.3f);
        DefensaDerechaAlta.SetActive(false);
        DefensaIzquierdaAlta.SetActive(false);
        DefensaDerechaMedia.SetActive(false);
        DefensaIzquierdaMedia.SetActive(false);
        DefensaDerechaBaja.SetActive(false);
        DefensaIzquierdaBaja.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InputDefensa();
    }
}
