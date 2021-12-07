using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Complemento : MonoBehaviour
{
    public float r1;
    public float r2;
    public float r3;
    public AudioClip[] clips;
    AudioSource audioSource;
    private int selector;
    Animator anim;
    bool bAnim = true;
    public void HacerSonido()
    {
        bAnim =false;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if(transform.position.x <= 0)
        {
            anim.SetBool("Derecha",true);
        }
        else if(transform.position.x >= 0)
        {
            anim.SetBool("Izquierda", true);
        }
        selector = Random.Range(0,clips.Length);
        audioSource.clip = clips[selector];
        audioSource.Play();
    }
    void DestruirComplemento()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(bAnim == true)
        {
            transform.Rotate(r1 * Time.deltaTime, r2 * Time.deltaTime, r3 * Time.deltaTime);
        }
    }
}
