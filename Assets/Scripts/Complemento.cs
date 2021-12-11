using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Complemento : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource audioSource;
    private int selector;
    Animator anim;
    public GameObject objParticulas;
    ParticleSystem particles;
    public void HacerSonido()
    {
        audioSource = GetComponent<AudioSource>();
        particles = objParticulas.GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();

        if(transform.position.x <= 0)
        {
            anim.SetBool("Derecha",true);
            particles.Play();
        }
        else if(transform.position.x >= 0)
        {
            anim.SetBool("Izquierda", true);
            particles.Play();
        }
        selector = Random.Range(0,clips.Length);
        audioSource.clip = clips[selector];
        audioSource.Play();
    }
    void DestruirComplemento()
    {
        Destroy(gameObject);
    }
}
