using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonUISetActive : MonoBehaviour
{
    public GameObject defensa;
    public string boolforAnim;

    public void ActivarObj()
    {
        defensa.SetActive(true);
        GameManager.Instance.Animator.SetBool(boolforAnim, true);
        StartCoroutine("TurnOff");
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.Animator.SetBool(boolforAnim, false);
        defensa.SetActive(false);
    }
}
