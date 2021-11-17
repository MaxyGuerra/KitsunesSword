using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public Transform derechaArriba;
    public Transform izquierdaArriba;
    public Transform derechaMedio;
    public Transform izquierdaMedio;
    public Transform derechaBajo;
    public Transform izquierdaBajo;

    private AudioSource audioSource;
    private float[] samples = new float[512];
    public float[] frequencyBand = new float[8];
    public float[] frecuencyForSpawn = new float[6];

    public float timer;
    public float spawnDelay;
    public GameObject PrefabBlanco;
    private GameObject ultimoBlanco;

    public float songDelay;
    public AudioSource audioCamara;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SongDelay");
    }

    void GetAudioSamples()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        float average = 0;
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int samepleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                samepleCount += 2;
            }

            for (int j = 0; j < samepleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            frequencyBand[i] = average;

        }
    }

    void SpawnBlancos()
    {
        frecuencyForSpawn[0] = frequencyBand[1];
        frecuencyForSpawn[1] = frequencyBand[2];
        frecuencyForSpawn[2] = frequencyBand[3];
        frecuencyForSpawn[3] = frequencyBand[4];
        frecuencyForSpawn[4] = frequencyBand[5];
        frecuencyForSpawn[5] = frequencyBand[6];

        float valorMaximo = 0f;

        for (int i = 0; i < frecuencyForSpawn.Length; i++)
        {
            if(frecuencyForSpawn[i] >= valorMaximo)
            {
                valorMaximo = frecuencyForSpawn[i];
            }
        }
        //Debug.Log(valorMaximo);
        for (int j = 0; j < frecuencyForSpawn.Length; j++)
        {
            if(frecuencyForSpawn[j] == valorMaximo)
            {
                if(frecuencyForSpawn[j] == frecuencyForSpawn[0])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaArriba.position,Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.Velocidad = -1f;
                }
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[1])
                {
                    Instantiate(PrefabBlanco, izquierdaArriba.position, Quaternion.identity);
                }
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[2])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaMedio.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.Velocidad = -1f;
                }
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[3])
                {
                    Instantiate(PrefabBlanco, izquierdaMedio.position, Quaternion.identity);
                }
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[4])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaBajo.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.Velocidad = -1f;
                }
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[5])
                {
                    Instantiate(PrefabBlanco, izquierdaBajo.position, Quaternion.identity);
                }
            }
        }
    }

    IEnumerator SongDelay()
    {
        yield return new WaitForSeconds(songDelay);
        audioCamara.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnDelay)
        {
            SpawnBlancos();
            timer = 0;
        }

        GetAudioSamples();
        MakeFrequencyBands();
    }
}
