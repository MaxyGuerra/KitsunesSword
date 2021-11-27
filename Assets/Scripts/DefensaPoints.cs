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
            GameManager.Instance.Animator.SetBool("BloqueoDerechoAlto", true);
            StartCoroutine("TurnOffCajas");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            DefensaIzquierdaAlta.SetActive(true);
            GameManager.Instance.Animator.SetBool("BloqueoIzquierdoAlto", true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            DefensaDerechaMedia.SetActive(true);
            GameManager.Instance.Animator.SetBool("BloqueoDerechoMedio", true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            DefensaIzquierdaMedia.SetActive(true);
            GameManager.Instance.Animator.SetBool("BloqueoIzquierdoMedio", true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            DefensaDerechaBaja.SetActive(true);
            GameManager.Instance.Animator.SetBool("BloqueoDerechoBajo", true);
            StartCoroutine("TurnOffCajas");
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            DefensaIzquierdaBaja.SetActive(true);
            GameManager.Instance.Animator.SetBool("BloquoIzquierdoBajo", true);
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
        GameManager.Instance.Animator.SetBool("BloqueoDerechoAlto", false);
        GameManager.Instance.Animator.SetBool("BloqueoIzquierdoAlto", false);
        GameManager.Instance.Animator.SetBool("BloqueoDerechoMedio", false);
        GameManager.Instance.Animator.SetBool("BloqueoIzquierdoMedio", false);
        GameManager.Instance.Animator.SetBool("BloqueoDerechoBajo", false);
        GameManager.Instance.Animator.SetBool("BloquoIzquierdoBajo", false);
    }

    // Update is called once per frame
    void Update()
    {
        InputDefensa();
    }
}
