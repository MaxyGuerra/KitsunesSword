using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISongButton : MonoBehaviour
{
    public int songIndex;
    public TextMeshProUGUI songName;
    AudioClip audioClip;

    public void Initialece(int index, string nombre, AudioClip cancion)
    {
        songIndex = index;
        songName.SetText(nombre);
        audioClip = cancion;
    }

    public void OnSelectClick()
    {
        GameManager.Instance.audioSource.clip = audioClip;
        Debug.Log(songIndex+songName.text);
    }
}
