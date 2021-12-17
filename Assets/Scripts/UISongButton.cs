using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISongButton : MonoBehaviour
{
    public int songIndex;
    public TextMeshProUGUI songName;

    public void Initialece(int index, string nombre)
    {
        songIndex = index;
        songName.SetText(nombre);
    }

    public void OnSelectClick()
    {
        Debug.Log(songIndex+songName.text);
    }
}
