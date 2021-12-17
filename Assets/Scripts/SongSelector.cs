using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelector : MonoBehaviour
{
    public AudioClip[] canciones;
    public GameObject botonPrefab;


    // Start is called before the first frame update
    void Start()
    {
        InitializeButtons();
    }

    void InitializeButtons()
    {
        for (int i = 0; i < canciones.Length; i++)
        {
            GameObject obj = Instantiate(botonPrefab, transform);
            obj.GetComponent<UISongButton>()?.Initialece(i,canciones[i].name);
        }
    }
}
