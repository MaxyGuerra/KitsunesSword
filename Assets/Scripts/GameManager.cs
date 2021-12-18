using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum EGameStates { Waiting, Gameplay, Pause, RoundOver, Gameover}
[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour
{
    public EGameStates gameStates;

    //Evento cambio de estados
    public delegate void FnotifyGameState(EGameStates gameStates);
    public static event FnotifyGameState OnGameStateChange;

    public bool bTimeIsRunnig;
    public bool bOnGameplay;

    public int blancoInicioCont = 2;

    //singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Transform derechaArriba;
    public Transform izquierdaArriba;
    public Transform derechaMedio;
    public Transform izquierdaMedio;
    public Transform derechaBajo;
    public Transform izquierdaBajo;

    public AudioSource audioSource;
    private float[] samples = new float[512];
    private float[] frequencyBand = new float[8];
    private float[] frecuencyForSpawn = new float[6];

    private float timer;
    public float spawnDelay;
    float delayForSpawn;
    public GameObject PrefabBlanco;
    public float velocidadBlancos;
    private GameObject ultimoBlanco;
    public int puntajeMaximo;
    public DefensaPoints defensaPoints;
    public TextMeshProUGUI puntajeMaximoUI;
    public GameObject capa1;
    public GameObject capa2;
    public float songDelay;
    public AudioSource audioCamara;
    public GameObject UISelector;

    public Animator Animator;
    
    private void Awake()
    {
        instance=this;
        audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeGameState(EGameStates.Waiting);
        puntajeMaximo = 0;
        UISelector.SetActive(true);
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
                /////////////////////////1/////////////////////////
                if (frecuencyForSpawn[j] == frecuencyForSpawn[0])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaArriba.position,Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = (velocidadBlancos * -1f);
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
                /////////////////////////2/////////////////////////
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[1])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, izquierdaArriba.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = velocidadBlancos;
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
                /////////////////////////3/////////////////////////
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[2])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaMedio.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = (velocidadBlancos * -1f);
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
                /////////////////////////4/////////////////////////
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[3])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, izquierdaMedio.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = velocidadBlancos;
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
                /////////////////////////5/////////////////////////
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[4])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, derechaBajo.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = (velocidadBlancos * -1f);
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
                /////////////////////////6/////////////////////////
                else if (frecuencyForSpawn[j] == frecuencyForSpawn[5])
                {
                    ultimoBlanco = Instantiate(PrefabBlanco, izquierdaBajo.position, Quaternion.identity);
                    Blanco setVelocidad = ultimoBlanco.GetComponent<Blanco>();
                    setVelocidad.velocidad = velocidadBlancos;
                    setVelocidad.AnnadirComplemento();
                    puntajeMaximo++;
                }
            }
        }
    }

    IEnumerator SongDelay()
    {
        audioCamara.clip = audioSource.clip;
        yield return new WaitForSeconds(songDelay);
        audioCamara.Play();
    }

    void StartGame()
    {
        StartCoroutine("SongDelay");
        ChangeGameState(EGameStates.Gameplay);
        audioSource.Play();
        //Debug.Log(audioSource.clip);
    }

    public void ChangeGameState(EGameStates NewGameStates)
    {
        gameStates = NewGameStates;
        OnGameStateChange?.Invoke(gameStates);

        switch (gameStates)
        {
            case EGameStates.Waiting:
                bTimeIsRunnig = true;
                bOnGameplay = false;
                break;
            case EGameStates.Gameplay:
                bTimeIsRunnig = true;
                bOnGameplay = true;
                //Debug.Log("gameplay");
                break;
            case EGameStates.Pause:
                bTimeIsRunnig = false;
                bOnGameplay = false;
                //Debug.Log("pausa");
                break;
            case EGameStates.RoundOver:
                bTimeIsRunnig = false;
                bOnGameplay = false;
                break;
            case EGameStates.Gameover:
                bTimeIsRunnig = false;
                bOnGameplay = false;
                break;
        }
    }

    public void UpdateWaitingState()
    {
        if(blancoInicioCont == 0) return;

        blancoInicioCont--;

        if(blancoInicioCont == 0)
        {
            StartGame();
        }
    }

    void GanasteElNivel()
    {
        puntajeMaximoUI.SetText(defensaPoints.puntaje+"/"+(puntajeMaximo-1));
        if(defensaPoints.puntaje >= ((puntajeMaximo-1)/3))
        {
            capa1.SetActive(true);
        }
        if (defensaPoints.puntaje >= ((puntajeMaximo-1) / 3) * 2)
        {
            capa2.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        GetAudioSamples();
        MakeFrequencyBands();
        
        if(audioSource.clip != null)
        {
            UISelector.SetActive(false);
        }
        
        if (bOnGameplay == true)
        {
            timer += Time.deltaTime;

            delayForSpawn = Random.Range((spawnDelay-0.5f),(spawnDelay+0.5f));

            if (timer >= delayForSpawn)
            {
                SpawnBlancos();
                timer = 0;
            }

            if(!audioSource.isPlaying)
            {
                ChangeGameState(EGameStates.RoundOver);
                GanasteElNivel();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gameStates)
            {
                case EGameStates.Gameplay:
                    ChangeGameState(EGameStates.Pause);
                    audioSource.Pause();
                    audioCamara.Pause();
                    break;
                case EGameStates.Pause:
                    ChangeGameState(EGameStates.Gameplay);
                    audioSource.UnPause();
                    audioCamara.UnPause();
                    break;
            }
        }
        
    }
}
